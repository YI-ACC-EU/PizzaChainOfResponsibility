﻿using System.Text;
using YI.ChainOfResponsibility;

const string OrdersDirectory = "C:\\Workspace\\Accademy\\Decorator";

//Inizio creazione di Chain-Of-Responsibility
//Creiamo gli handler
var pizzaHandler = new PizzaTypeHandler();
var doughHandler = new DoughHandler();
var addsHandler = new AddsHandler();
//Definiamo la catena
pizzaHandler.SetSuccesor(doughHandler);
doughHandler.SetSuccesor(addsHandler);
//Fine creazione di Chain-Of-Responsibility

//Creiamo repository che se ne occuperà di persistenza. Lettura e scrittura dei dati sul filesystem
var orderRepository = new OrderRepository();
var directoryInfo = orderRepository.GetFileNames(OrdersDirectory);
var progressivo = 1;
var orderTotalsStringBuilder = new StringBuilder();
foreach(var file in directoryInfo)
{
    var orderId = $"order number { progressivo++ }";
    var orderLines = orderRepository.GetOrderLines(file);
    var orderItems = new List<Pizza>();
    foreach(var line in orderLines)
    {
        var pizzaComponents = line.Split(';');

        //usiamo il pattern Builder
        var pizza = PizzaBuilder
            .Create()
            .WithPizzaType(pizzaComponents[0])
            .WithDough(pizzaComponents[1])
            .WithComponents(pizzaComponents[2].Split(','))
            .Build();
        pizzaHandler.ProcessPrice(pizza);
        orderItems.Add(pizza);
    }
    orderTotalsStringBuilder.AppendLine(
        $"OrderNum: {progressivo}; Totals: {orderItems.Sum(x=>x.GetTotals())}");
}
orderRepository.SaveToFile(
    @"C:\\Workspace\\Accademy\\Decorator\\OrderTotals.TXT", 
    orderTotalsStringBuilder.ToString());