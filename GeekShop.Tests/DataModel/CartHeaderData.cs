using GeekShop.Tests.Models.CartModel;

namespace GeekShop.Tests.DataModel
{
    public class CartHeaderData
    {
        public List<CartHeader> CartHeaderList()
        {
            List<CartHeader> listOfCartHeader = new List<CartHeader>()
            {
                new CartHeader()
                {
                    Id = 1,
                    UserId = new Guid().ToString(),
                    CouponCode = "RML_2023_05",
                    DiscountAmount = 5
                },
                new CartHeader()
                {
                    Id = 2,
                    UserId = new Guid().ToString(),
                    CouponCode = "RML_2023_10",
                    DiscountAmount = 10
                },
                new CartHeader()
                {
                    Id = 3,
                    UserId = new Guid().ToString(),
                    CouponCode = "RML_2023_15",
                    DiscountAmount = 15
                }
            };
            return listOfCartHeader;
        }
    }
}
