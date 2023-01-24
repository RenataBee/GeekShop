using GeekShop.CartApi.DTOs;
using GeekShop.CartApi.IRepository;
using GeekShop.CartApi.IService;

namespace GeekShop.CartApi.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            var isApplied = _cartRepository.ApplyCoupon(userId, couponCode);
            return isApplied;
        }

        public Task<bool> ClearCart(string userId)
        {
            var isCleaned = _cartRepository.ClearCart(userId);
            return isCleaned;
        }

        public Task<CartDto> FindCartByUserId(string userId)
        {
            var cartDto = _cartRepository.FindCartByUserId(userId);
            return cartDto;
        }

        public Task<bool> RemoveFromCart(int cartDetailId)
        {
            var isRemoved = _cartRepository.RemoveFromCart(cartDetailId);
            return isRemoved;
        }

        public Task<CartDto> SaveOrUpdateCart(CartDto cartDto)
        {
            var cartDtoDB = _cartRepository.SaveOrUpdateCart(cartDto);
            return cartDtoDB;
        }
    }
}
