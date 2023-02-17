using GeekShop.Tests.Models.CartModel;

namespace GeekShop.Tests.DataModel
{
    public class CartDetailData
    {
        public List<CartDetail> CartDetailList()
        {
            List<CartDetail> listOfCartDetail = new List<CartDetail>()
            {
                new CartDetail()
                {
                    Id = 1,
                    CartHeaderId = 1,
                    ProductId = 1,
                    Count = 1
                },
                new CartDetail()
                {
                    Id = 2,
                    CartHeaderId = 2,
                    ProductId = 2,
                    Count = 1
                },
                new CartDetail()
                {
                    Id = 3,
                    CartHeaderId = 3,
                    ProductId = 3,
                    Count = 2
                }
            };
            return listOfCartDetail;
        }
    }
}
