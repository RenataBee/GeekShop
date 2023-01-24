namespace GeekShop.Web.Models
{
    public class CartDetailViewModel
    {
        public int CartHeaderId { get; set; }
        public virtual CartHeaderViewModel CartHeader { get; set; }
        public int ProductId { get; set; }
        public virtual ProductViewModel Product { get; set; }
        public int Count { get; set; }
    }
}
