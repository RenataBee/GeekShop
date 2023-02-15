using GeekShop.Mock.IRepository;
using GeekShop.Mock.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GeekShop.Mock
{
    [TestClass]
    public class UnitTest
    {
        private readonly GetProductRepository _product;
        private readonly ProductData _productData;

        public UnitTest()
        {
            _productData = new ProductData();
            _product = new GetProductRepository(_productData);
            
        }

        [TestMethod]
        public void GetAllProducts()
        {
            //arrange
            var listOfProducts = _product.GetProducts();
            Mock<IGetProductRepository> mock = new Mock<IGetProductRepository>();
            mock.Setup(p => p.GetProducts()).Returns(listOfProducts);
            GetProductRepository product = new GetProductRepository(_productData);

            //act
            var resultadoEsperado = mock.Object.GetProducts();
            var resultado = product.GetProducts();

            //assert
            Assert.AreEqual(listOfProducts.Count, resultado.Count);
        }
    }
}
