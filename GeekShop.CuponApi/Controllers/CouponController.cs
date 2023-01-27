using GeekShop.CouponApi.DTOs;
using GeekShop.CouponApi.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShop.CouponApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService ?? throw new ArgumentNullException(nameof(couponService));
        }

        [HttpGet("{couponCode}")]
        [Authorize]
        public async Task<ActionResult<CouponDTO>> GetCouponByCouponCode(string couponCode)
        {
            var couponDtoBD = await _couponService.GetCouponByCouponCode(couponCode);

            if (couponDtoBD == null) return NotFound();
            return Ok(couponDtoBD);
        }
    }
}
