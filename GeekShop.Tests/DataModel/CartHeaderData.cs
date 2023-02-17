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
                    UserId = "b1daa517-7101-4200-8dba-cf6a49161eaa",
                    CouponCode = "RML_2023_05",
                    DiscountAmount = 5
                },
                new CartHeader()
                {
                    Id = 2,
                    UserId = "b1daa517-7101-4200-8dba-cf6a49161aee",
                    CouponCode = "RML_2023_10",
                    DiscountAmount = 10
                },
                new CartHeader()
                {
                    Id = 3,
                    UserId = "b1daa517-7101-4200-8dba-cf6a49161fbb",
                    CouponCode = "RML_2023_15",
                    DiscountAmount = 15
                }
            };
            return listOfCartHeader;
        }
    }
}
