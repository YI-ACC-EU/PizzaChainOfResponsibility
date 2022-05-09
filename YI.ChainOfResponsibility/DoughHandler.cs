namespace YI.ChainOfResponsibility
{
    public class DoughHandler : PriceFiller
    {
        public override void ProcessPrice(Pizza pizza)
        {

            if (pizza.TipoPizza.ItemName.Equals("integrale", StringComparison.InvariantCultureIgnoreCase))
                pizza.TipoPizza.Ammount = 1M;
            else
                pizza.TipoPizza.Ammount = 0M;
            _next?.ProcessPrice(pizza);
        }
    }
}
