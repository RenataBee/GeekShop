using GeekShop.Web.Models;

namespace GeekShop.Web.Services.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProducts(string token);
        Task<ProductModel> GetProductById(int id, string token);
        Task<ProductModel> AddProduct(ProductModel input, string token);
        Task<ProductModel> UpdateProduct(ProductModel input, string token);
        Task<bool> DeleteProduct(int id, string token);
    }
}
