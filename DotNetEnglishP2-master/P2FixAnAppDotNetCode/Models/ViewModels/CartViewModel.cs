namespace P2FixAnAppDotNetCode.Models.ViewModels
{
    public class CartViewModel
    {
        public int OrderLineId { get; set; }
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
    }
}
