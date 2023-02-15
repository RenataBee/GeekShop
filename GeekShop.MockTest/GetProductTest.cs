using GeekShop.MockTest.Models;
using Moq;

namespace GeekShop.MockTest
{
    public class GetProductTest
    {
        [Fact]
        public void RetornarListaDeProdutos()
        {

            //arrange
            CreateListOfProducts createListOfProducts = new CreateListOfProducts();
            var listOfProducts = createListOfProducts.CreateProductArray();
            Mock<IGetProducts> mock = new Mock<IGetProducts>();
            mock.Setup(m => m.GetProducts()).Returns(listOfProducts);
            GetProducts products = new GetProducts();

            //act
            var resultExpected = mock.Object.GetProducts();
            var result = products.Get


            //arrange
            //Mock<IVerificadorPrecoProduto> mock = new Mock<IVerificadorPrecoProduto>();
            //mock.Setup(m => m.VerificaPrecoProduto(produtoBarato)).Returns("Produto barato!");
            //VerificadorPrecoProduto verif = new VerificadorPrecoProduto();

            //act
            //var resultadoEsperado = mock.Object.VerificaPrecoProduto(produtoBarato);
            //var resultado = verif.VerificaPrecoProduto(produtoBarato);

            //assert

            //assert
        }
    }
}