using GeekShop.Mock.IRepository;
using GeekShop.Mock.Models;
using GeekShop.Mock.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace GeekShop.Mock
{
    [TestClass]
    public class UnitTest
    {
        private readonly ProductRepository _product;
        private readonly ProductData _productData;

        public UnitTest()
        {
            _productData = new ProductData();
            _product = new ProductRepository(_productData);

        }

        [TestMethod]
        public void GetAllProducts()
        {
            //arrange
            var listOfProducts = _product.GetAllProducts();
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.GetAllProducts()).Returns(listOfProducts);
            ProductRepository product = new ProductRepository(_productData);

            //act
            var expectedOutcome = mock.Object.GetAllProducts();
            var result = product.GetAllProducts();

            //assert
            Assert.AreEqual(listOfProducts.Count, result.Count);
        }

        [TestMethod]
        [DataRow(2)]
        public void GetProductById(int id)
        {
            //arrange
            var product = _product.GetProductById(id);
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.GetProductById(id)).Returns(product);
            ProductRepository productRepository = new ProductRepository(_productData);

            //act
            var expectedOutcome = mock.Object.GetProductById(id);
            var result = productRepository.GetProductById(id);

            //assert
            Assert.AreEqual(product, expectedOutcome);
        }

        [TestMethod]
        public void AddProduct()
        {
            //arrange
            var isAdded = _product.AddProduct();
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.AddProduct()).Returns(isAdded);
            ProductRepository productsRepository = new ProductRepository(_productData);

            //act
            var expectedOutcome = mock.Object.AddProduct();
            var result = productsRepository.AddProduct();

            //Assert
            Assert.AreEqual(expectedOutcome, result);
        }

        [TestMethod]
        [DataRow(2)]
        public void UpdateProduct(int id)
        {
            //arrange
            var isUpdated = _product.UpdateProduct(id);
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.UpdateProduct(id)).Returns(isUpdated);
            ProductRepository productRepository = new ProductRepository(_productData);

            //act
            var expectedOutcome = mock.Object.UpdateProduct(id);
            var result = productRepository.UpdateProduct(id);

            //assert
            Assert.AreEqual(expectedOutcome, result);
        }

        [TestMethod]
        [DataRow(2)]
        public void DeleteProduct(int id)
        {
            //arrange
            var isUpdated = _product.DeleteProduct(id);
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.DeleteProduct(id)).Returns(isUpdated);
            ProductRepository productRepository = new ProductRepository(_productData);

            //act
            var expectedOutcome = mock.Object.DeleteProduct(id);
            var result = productRepository.DeleteProduct(id);

            //assert
            Assert.AreEqual(expectedOutcome, result);
        }
    }
}
