namespace LoginApp
{
    public class ContentViewModel
    {
        public ContentViewModel(PurchacesViewModel purchacesViewModel, OrderViewModel orderViewModel)
        {
            this.PurchacesViewModel = purchacesViewModel;
            this.OrderViewModel = orderViewModel;
        }

        public PurchacesViewModel PurchacesViewModel { get; }

        public OrderViewModel OrderViewModel { get; }
    }
}