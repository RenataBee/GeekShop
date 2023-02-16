/* Critérios de aceite : 
 * 1. Criar as entidades com todas as suas propriedades;
 * 2. As ações devem ser todas testas (Adicionar um Coupon, Limpar Carrinho de Compras, Encontrar Carrinho por Id, Remover item do carrinho
 *    Remover coupon, Salvar-Atualizar um coupon
 * 3. A nível de testes o userId deve ser usado com um Guid gerado via código  
 * 4. Todos os campos são obrigatórios
 */

using GeekShop.Tests.DataModel;
using GeekShop.Tests.Models.CartModel;
using Xunit.Abstractions;

namespace GeekShop.Tests
{
    public class CartTests
    {
        private readonly CartDetailData _cartDetailData;
        private readonly ITestOutputHelper _testOutputHelper;

        //constants
        private const int _expectedCountCartDetail = 4;

        public CartTests(CartDetailData cartDetailData, ITestOutputHelper testOutputHelper)
        {
            _cartDetailData = cartDetailData;
            _testOutputHelper = testOutputHelper;
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

        [Fact]
        public void AddNewCartDetail()
        {
            //arrange
            CartDetail cartDetail = new CartDetail()
            {
                Id = 1001,
                CartHeaderId = 1,
                ProductId = 1,
                Count = 1
            };


            //Act
            var cartDeailList = _cartDetailData.CartDetailList();
            if (cartDeailList.Count > 0)
                cartDeailList.Add(cartDetail);

            ////Assert
            _testOutputHelper.WriteLine($"O produto adicionado foi: {_expectedCountCartDetail}");
            Assert.Equal(expected: _expectedCountCartDetail, actual: cartDeailList.Count);
        }

        public void SaveOrUpdateCart()
        {
            var isAdded = false;
            Cart cart = new Cart()
            {


            };
        }
    }
}