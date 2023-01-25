using GeekShop.CartApi.DTOs;
using GeekShop.CartApi.IService;
using GeekShop.CartApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace GeekShop.CartApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
        }

        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<CartDto>> FindCartByUserId(string id)
        {
            var cartDtoDB = await _cartService.FindCartByUserId(id);

            if (cartDtoDB == null) return NotFound();
            return Ok(cartDtoDB);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartDto>> AddCart([FromBody] CartDto input)        
        {
            var cart = await _cartService.SaveOrUpdateCart(input);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartDto>> UpdateCart(CartDto cartDto)
        {
            var cartDtoDb = await _cartService.SaveOrUpdateCart(cartDto);

            if (cartDto == null) return NotFound();
            return Ok(cartDto);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<bool>> RemoveCart(int id)
        {
            //cartDetailId
            var isRemoved = await _cartService.RemoveFromCart(id);

            if (!isRemoved) return NotFound();
            return Ok(isRemoved);
        }
    }
}