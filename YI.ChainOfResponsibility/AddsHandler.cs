namespace YI.ChainOfResponsibility
{
    public class AddsHandler : PriceFiller
    {
        public override void ProcessPrice(Pizza pizza)
        {
            //processare prezzo degli componenti aggiuntivi
            foreach(var component in pizza.Components)
            {
                if (component.Equals("capperi", StringComparison.CurrentCultureIgnoreCase))
                    component.Ammount = 0.5M;
                else if (component.Equals("olive", StringComparison.CurrentCultureIgnoreCase))
                    component.Ammount = 0.6M;

            }
            _next?.ProcessPrice(pizza);
        }
    }
}
