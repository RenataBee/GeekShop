/* Critérios de aceite : 
 * 1. 
 * 2.     
 * 3. 
 */

using GeekShop.Tests.Models.CartModel;
using Xunit.Abstractions;

namespace GeekShop.Tests
{
    public class CartTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public CartTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        public void ApplyCoupon(string userId, string couponCode)
        {

        }

        public void ClearCart(string userId)
        {

        }

        public void FindCartByUserId(string userId)
        {

        }

        public void RemoveFromCart(int cartDetailId)
        {

        }

        public void RemoveCoupon(string userId)
        {

        }

        public void SaveOrUpdateCart(Cart cartDto)
        {

        }
    }
}