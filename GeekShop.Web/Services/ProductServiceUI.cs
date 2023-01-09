using GeekShop.Web.Models;
using GeekShop.Web.Services.IService;
using GeekShop.Web.Utils;

namespace GeekShop.Web.Services
{
    public class ProductServiceUI : IProductServiceUI
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProductServiceUI(HttpClient client)
        {
            _client = client ?? throw new ArgumentException(nameof(ProductServiceUI));            
        }

        public async Task<IEnumerable<ProductModel>> GetProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAsync<List<ProductModel>>();
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAsync<ProductModel>(); 
        }

        public async Task<ProductModel> AddProduct(ProductModel input)
        {
            var response = await _client.PostAsJson(BasePath, input);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAsync<ProductModel>(); 
            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<ProductModel> UpdateProduct(ProductModel input)
        {
            var response = await _client.PutAsJson(BasePath, input);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAsync<ProductModel>();
            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAsync<bool>();
            else
                throw new Exception("Something went wrong when calling API");
        }
    }
}
