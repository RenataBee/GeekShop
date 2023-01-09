using GeekShop.Web.Models;

namespace GeekShop.Web.Services.IService
{
    public interface IProductServiceUI
    {
        Task<IEnumerable<ProductModel>> GetProducts();
        Task<ProductModel> GetProductById(int id);
        Task<ProductModel> AddProduct(ProductModel input);
        Task<ProductModel> UpdateProduct(ProductModel input);
        Task<bool> DeleteProduct(int id);
    }
}
