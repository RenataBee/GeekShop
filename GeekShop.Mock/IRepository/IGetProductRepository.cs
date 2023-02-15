using GeekShop.Mock.Models;
using System.Collections.Generic;

namespace GeekShop.Mock.IRepository
{
    public interface IGetProductRepository
    {
        List<Product> GetProducts();
    }
}
