using AutoMapper;
using GeekShop.ProductApi.DTOs;
using GeekShop.ProductApi.IRepository;
using GeekShop.ProductApi.Model;
using GeekShop.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace GeekShop.ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ProductRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> products = await _dataContext.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            Product product = await _dataContext.Products.
                Where(p => p.Id == id). 
                FirstOrDefaultAsync() ?? new Product();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> AddProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _dataContext.Products.Add(product);

            await _dataContext.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);

        }

        public async Task<ProductDto> UpdateProduct(ProductDto productDto)
        {
            var dbProduct = await _dataContext.Products.Where(p => p.Id == productDto.Id).FirstOrDefaultAsync();
            var product = _mapper.Map<Product>(productDto);

            if (dbProduct != null)
            {
                dbProduct.Name = product.Name;
                dbProduct.Description = product.Description;
                dbProduct.price = product.price;
                dbProduct.CategoryName = product.CategoryName;
                dbProduct.ImageUrl = product.ImageUrl; 
            }

            _dataContext.Update(product);
            await _dataContext.SaveChangesAsync();
            return _mapper.Map<ProductDto>(dbProduct);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var dbProduct = await _dataContext.Products.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Product();
                
                if (dbProduct.Id <= 0) return false;
                _dataContext.Remove(dbProduct);
                
                await _dataContext.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
