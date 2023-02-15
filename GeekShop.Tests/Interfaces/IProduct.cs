using GeekShop.Tests.Models.ProductModel;

namespace GeekShop.Tests.Interfaces
{
    public interface IProduct
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        bool AddProduct();
        bool UpdateProduct(int id);
        bool DeleteProduct(int id);
    }
}
