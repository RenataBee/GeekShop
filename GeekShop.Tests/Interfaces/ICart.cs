using GeekShop.Tests.Models.CartModel;

namespace GeekShop.Tests.Interfaces
{
    public interface ICart
    {
        bool ApplyCoupon(string userId, string couponCode);
        bool ClearCart(string userId);
        Cart FindCartByUserId(string userId);
        bool RemoveFromCart(int cartDetailId);
        bool RemoveCoupon(string userId);
        Cart SaveOrUpdateCart(Cart cart);
    }
}
