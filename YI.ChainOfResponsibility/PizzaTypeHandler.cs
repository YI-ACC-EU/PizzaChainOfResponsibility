namespace YI.ChainOfResponsibility
{
    public class PizzaTypeHandler : PriceFiller
    {
        public override void ProcessPrice(Pizza pizza)
        {
            // processare il prezzo
            throw new NotImplementedException();

            _next?.ProcessPrice(pizza);
        }
    }
}
