using GeekShop.Web.Models;

namespace GeekShop.Web.Services.IService
{
    public interface ICartService
    {
        Task<CartViewModel> AddItemToCart(CartViewModel model, string token);
        Task<CartViewModel> FindCartByUserId(string userId, string token);
        Task<bool> RemoveFromCart(int cartDetailId, string token);
        Task<CartViewModel> UpdateCart(CartViewModel model, string token);

        Task<bool> ApplyCoupon(CartViewModel cart, string couponCode, string token);
        Task<bool> RemoveCoupon(string userId, string token);
        Task<bool> ClearCart(string userId, string token);
        Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token);
    }
}
