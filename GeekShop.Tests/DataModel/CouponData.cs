using GeekShop.Tests.Models.CouponModel;

namespace GeekShop.Tests.DataModel
{
    public class CouponData
    {
        public List<Coupon> CouponsList()
        {
            List<Coupon> listOfCoupons = new List<Coupon>()
            {
                new Coupon()
                {
                    Id = 1,
                    CouponCode = "RML_2023_05",
                    DiscountAmount = 5
                },
                new Coupon()
                {
                    Id = 2,
                    CouponCode = "RML_2023_10",
                    DiscountAmount = 10

                },
                 new Coupon()
                {
                    Id = 3,
                    CouponCode = "RML_2023_15",
                    DiscountAmount = 15

                }
            };
            return listOfCoupons;
        }
    }
}
