namespace YI.ChainOfResponsibility
{
    public class AddsHandler : PriceFiller
    {
        public override void ProcessPrice(Pizza pizza)
        {
            //processare prezzo degli componenti aggiuntivi
            throw new NotImplementedException();
            _next?.ProcessPrice(pizza);
        }
    }
}
