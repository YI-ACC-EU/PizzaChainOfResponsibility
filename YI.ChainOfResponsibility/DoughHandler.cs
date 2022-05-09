namespace YI.ChainOfResponsibility
{
    public class DoughHandler : PriceFiller
    {
        public override void ProcessPrice(Pizza pizza)
        {
            // appicare il prezzo dell'impasto.
            throw new NotImplementedException();

            _next?.ProcessPrice(pizza);
        }
    }
}
