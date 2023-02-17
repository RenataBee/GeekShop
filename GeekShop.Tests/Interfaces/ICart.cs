using GeekShop.Tests.Models.CartModel;

namespace GeekShop.Tests.Interfaces
{
    public interface ICart
    {
        bool ClearCart(string userId);
        Cart FindCartByUserId(string userId);
        bool RemoveFromCart(int cartDetailId);
        Cart SaveOrUpdateCart(Cart cart);
    }
}
