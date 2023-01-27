using GeekShop.CouponApi.DTOs;

namespace GeekShop.CouponApi.IServices
{
    public interface ICouponService
    {
        Task<CouponDTO> GetCouponByCouponCode(string couponCode);
    }
}
