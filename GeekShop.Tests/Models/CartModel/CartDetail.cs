using GeekShop.Tests.Models.ProductModel;

namespace GeekShop.Tests.Models.CartModel
{
    public class CartDetail
    {
        public int Id { get; set; }
        public int CartHeaderId { get; set; }
        public virtual CartHeader CartHeader { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Count { get; set; }
    }
}
