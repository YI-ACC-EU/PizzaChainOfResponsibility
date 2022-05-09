namespace YI.ChainOfResponsibility
{
    public class DoughHandler : PriceFiller
    {
        public DoughHandler(IPriceManager priceManager) 
            : base(priceManager){ }

        public override void ProcessPrice(Pizza pizza)
        {
            pizza.TipoPizza.Ammount = _priceManager.GetPrice(pizza.TipoPizza.ItemName);
            _next?.ProcessPrice(pizza);
        }
    }
}
