using GeekShop.Mock.IRepository;
using GeekShop.Mock.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekShop.Mock.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductData _productData;

        public ProductRepository(ProductData productData)
        {
            _productData = productData;
        }

        public Product GetProductById(int id)
        {
            var listOfProducts = _productData.CreateProductArray();
            Product productReturned = listOfProducts.FirstOrDefault(p => p.Id == id);

            return productReturned;
        }

        public List<Product> GetAllProducts()
        {
            var listOfProducts = _productData.CreateProductArray();
            return listOfProducts;
        }

        public bool AddProduct()
        {
            var isAdded = false;
            Product newProduct = new Product()
            {
                Id = 4,
                Name = "CANECA HELLO KITTY REDONDA",
                Price = Convert.ToDecimal(16.99),
                Description = "A Caneca da Hello Kitty redonda, foi desenvolvida pela Piticas para expressar o seu lado fã da Personagem. Feira em cerâmica possuí capacidade 300ml | Medida: 8,5cm x 13,cm x 8cm",
                CategoryName = "Canecas",
                ImageUrl = "https://tfcprw.vtexassets.com/arquivos/ids/162012-800-auto?v=637976666992800000&width=800&height=auto&aspect=true"
            };

            List<Product> listOfProducts = _productData.CreateProductArray();
            listOfProducts.Add(newProduct);

            foreach (var item in listOfProducts)
            {
                if (item.Id == 4)
                {
                    isAdded = true;
                    return isAdded;
                }                
            }           

            return isAdded;
        }
        public bool UpdateProduct(int id)
        {
            var isUpdated = false;
            var listOfProducts = _productData.CreateProductArray();
            var productReturned = listOfProducts.Where(p => p.Id == id).FirstOrDefault();

            Product product = new Product()
            {
                Id = 2,
                Name = "UPDATE NAME OF PRODUCT",
                Price = Convert.ToDecimal(15.99),
                Description = "A Caneca Stranger Things Chibi é um produto original e licenciado da Piticas. Feito para você expressar o seu lado fã da série Stranger Things. Ideal para presentear ou colecionar. Caneca de cerâmica - Altura: 14,5cm | Comprimento: 10cm | Largura: 9,5cm capacidade: 400ml",
                CategoryName = "Canecas",
                ImageUrl = "https://tfcprw.vtexassets.com/arquivos/ids/166882-800-auto?v=637976691643600000&width=800&height=auto&aspect=true"
            };

            productReturned = product;
            if (productReturned.Name.Contains("UPDATE"))
            {
                isUpdated = true;
            }
            return isUpdated;
        }

        public bool DeleteProduct(int id)
        {
            var isDeleted = false;
            var listOfProducts = _productData.CreateProductArray();
            Product productReturned = listOfProducts.FirstOrDefault(p => p.Id == id);

            if (productReturned != null)
            {
                foreach (var item in listOfProducts)
                {
                    if (item.Id == id)
                    {
                        listOfProducts.Remove(item);
                        isDeleted = true;
                        return isDeleted;
                    }
                }
            }
            return isDeleted;
        }
    }
}
