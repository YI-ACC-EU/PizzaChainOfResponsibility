namespace YI.ChainOfResponsibility
{
    public class PizzaTypeHandler : PriceFiller
    {
        public override void ProcessPrice(Pizza pizza)
        {

            if (pizza.TipoPizza.ItemName.Equals("margherita", StringComparison.InvariantCultureIgnoreCase))
                pizza.TipoPizza.Ammount = 5.0M;
            else if(pizza.TipoPizza.ItemName.Equals("marinara", StringComparison.InvariantCultureIgnoreCase))
                pizza.TipoPizza.Ammount = 6.0M;
            _next?.ProcessPrice(pizza);
        }
    }
}
