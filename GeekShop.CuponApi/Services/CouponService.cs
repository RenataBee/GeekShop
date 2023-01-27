using GeekShop.CouponApi.DTOs;
using GeekShop.CouponApi.IRepository;
using GeekShop.CouponApi.IServices;

namespace GeekShop.CouponApi.Services
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;

        public CouponService(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public async Task<CouponDTO> GetCouponByCouponCode(string couponCode)
        {
            var couponDtoBD = await _couponRepository.GetCouponByCouponCode(couponCode);
            return couponDtoBD;
        }
    }
}
