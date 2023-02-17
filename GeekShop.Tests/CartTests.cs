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
        private CartDetailData _cartDetailData = new CartDetailData();
        private CartHeaderData _cartHeaderData = new CartHeaderData();
        private readonly ITestOutputHelper _outputHelper;

        private const int _expectedCountAfterDeleteFromCart = 2;
        private const int _expectedCountAfterRemoveFromCart = 2;

        //constants
        private const int _expectedCountCartDetail = 4;

        public CartTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Theory]
        [InlineData("b1daa517-7101-4200-8dba-cf6a49161fbb")]
        public void ClearCart(string userId)
        {
            //arrange
            var listOfCartHeader = _cartHeaderData.CartHeaderList();            
            var cartHeader = listOfCartHeader.FirstOrDefault(c => c.UserId == userId);

            var listOfCartDetails = _cartDetailData.CartDetailList();

            //act
            if (cartHeader != null)
            {
                var cartDetail = listOfCartDetails.FirstOrDefault(d => d.CartHeaderId == cartHeader.Id);

                if (cartDetail != null)
                listOfCartDetails.Remove(cartDetail);
            }

            //assert
            _outputHelper.WriteLine($"O produto removido do carrinho foi: {cartHeader.Id}");
            Assert.Equal(expected: _expectedCountAfterRemoveFromCart, actual: listOfCartDetails.Count);
        }

        [Theory]
        [InlineData("b1daa517-7101-4200-8dba-cf6a49161fbb")]
        public void FindCartByUserId(string userId)
        {
            //arrange
            var listOfCartHeader = _cartHeaderData.CartHeaderList();
            int id = 0;
            Cart cart = new Cart()
            {
                CartHeader = listOfCartHeader.FirstOrDefault(c => c.UserId == userId) ?? new CartHeader()
            };

            //act
            if (cart != null)
            {
                var listOfCartDetails = _cartDetailData.CartDetailList();
                cart.CartDetails = listOfCartDetails.Where(c => c.CartHeaderId == cart.CartHeader.Id);
                id = cart.Id;
            }

            //assert
            _outputHelper.WriteLine($"O produto retornado é: {cart.Id}");
            Assert.Equal(expected: cart.Id, actual: id);
        }

        [Theory]
        [InlineData(2)]
        public void RemoveFromCart(int cartDetailId)
        {
            //arrange
            var listOfCartDetails = _cartDetailData.CartDetailList();
            var cartDetail = listOfCartDetails.FirstOrDefault(c => c.Id == cartDetailId);

            //act
            listOfCartDetails.Remove(cartDetail);

            //assert
            _outputHelper.WriteLine($"O produto deletado do carrinho foi: {cartDetail.Id}");
            Assert.Equal(expected: _expectedCountAfterDeleteFromCart, actual: listOfCartDetails.Count);
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
            _outputHelper.WriteLine($"O produto adicionado foi: {_expectedCountCartDetail}");
            Assert.Equal(expected: _expectedCountCartDetail, actual: cartDeailList.Count);
        }
    }
}