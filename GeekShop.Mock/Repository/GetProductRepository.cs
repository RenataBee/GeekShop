using GeekShop.Mock.IRepository;
using GeekShop.Mock.Models;
using System.Collections.Generic;

namespace GeekShop.Mock.Repository
{
    public class GetProductRepository : IGetProductRepository
    {
        private readonly ProductData _productData;

        public GetProductRepository(ProductData productData)
        {
            _productData = productData;
        }

        public List<Product> GetProducts()
        {
            var listOfProducts = _productData.CreateProductArray();
            return listOfProducts;
        }
    }
}
