namespace LoginApp
{
    public class ContentViewModel
    {
        public PurchacesViewModel PurchacesViewModel { get; } = new PurchacesViewModel();

        public OrderViewModel OrderViewModel { get; } = new OrderViewModel();
    }
}