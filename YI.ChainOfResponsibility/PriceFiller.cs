namespace YI.ChainOfResponsibility
{
    public abstract class PriceFiller
    {
        protected PriceFiller? _next;
        public void  SetSuccesor(PriceFiller next)
        {
            _next = next;
        }
        public abstract void ProcessPrice(Pizza pizza);
    }
}
