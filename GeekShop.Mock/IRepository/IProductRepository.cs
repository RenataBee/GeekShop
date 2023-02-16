using GeekShop.Mock.Models;
using System.Collections.Generic;

namespace GeekShop.Mock.IRepository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        bool AddProduct();
        bool UpdateProduct(int id);
        bool DeleteProduct(int id);
    }
}
