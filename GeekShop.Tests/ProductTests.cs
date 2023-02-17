
/* Critérios de aceite : 
 * 1. Criar produto com Id, Name, Price,Description,CategoryName,ImageUrl.
 * 2. As ações devem ser todas testadas : Pesquisar todos os produtos, Pesquisar um produto especifico, 
 *    Adicionar um produto, atualizar um produto, deletar um produto.
 * 3. Todos os campos são obrigatórios 
 */

using GeekShop.Tests.DataModel;
using GeekShop.Tests.Interfaces;
using GeekShop.Tests.Models.ProductModel;
using Xunit.Abstractions;

namespace GeekShop.Tests
{
    public class ProductTests : IProduct
    {
        private ProductData _productData = new ProductData();
        private readonly ITestOutputHelper _outputHelper;

        private const int _countOfList = 3;
        private const int _expectedNumberOfProductsAfterAdd = 4;
        private const int _expectedNumberOfProductsAfterDelete = 2;

        private const string _nameOfProductAfterUpdate = "NAME OF PRODUCT";

        public ProductTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        List<Product> IProduct.GetProducts()
        {
            //Arrange
            var listOfProducts = new List<Product>();
            listOfProducts = _productData.CreateProductArray();

            //Act
            var countList = listOfProducts.Count;

            ////Assert
            _outputHelper.WriteLine($"O resultado esperado é: {_countOfList}");
            Assert.Equal(expected: _countOfList, actual: countList);
            return listOfProducts;
        }

        [Theory]
        [InlineData(2)]
        Product IProduct.GetProductById(int id)
        {
            //Arrange
            var listOfProducts = _productData.CreateProductArray();

            //Act
            var product = listOfProducts.FirstOrDefault(p => p.Id == id);

            ////Assert
            _outputHelper.WriteLine($"O produto retornado é: {product.Id}");
            Assert.Equal(expected: product.Id, actual: id);
            return product;
        }

        [Fact]
        bool IProduct.AddProduct()
        {
            var isAdded = false;
            //Arrange
            Product product = new Product()
            {
                Id = 4,
                Name = "CANECA HELLO KITTY REDONDA",
                Price = Convert.ToDecimal(16.99),
                Description = "A Caneca da Hello Kitty redonda, foi desenvolvida pela Piticas para expressar o seu lado fã da Personagem. Feira em cerâmica possuí capacidade 300ml | Medida: 8,5cm x 13,cm x 8cm",
                CategoryName = "Canecas",
                ImageUrl = "https://tfcprw.vtexassets.com/arquivos/ids/162012-800-auto?v=637976666992800000&width=800&height=auto&aspect=true"
            };

            //Act
            var listOfProducts = _productData.CreateProductArray();
            if (listOfProducts.Count > 0)
                listOfProducts.Add(product);

            if (_expectedNumberOfProductsAfterAdd == listOfProducts.Count)
                isAdded = true;

            ////Assert
            _outputHelper.WriteLine($"O produto adicionado foi: {_expectedNumberOfProductsAfterAdd}");
            Assert.Equal(expected: _expectedNumberOfProductsAfterAdd, actual: listOfProducts.Count);
            return isAdded;
        }

        [Theory]
        [InlineData(2)]
        bool IProduct.UpdateProduct(int id)
        {
            var isUpdated = false;
            //Arrange
            var listOfProducts = _productData.CreateProductArray();
            var productReturn = listOfProducts.Where(p => p.Id == id).FirstOrDefault();

            Product product = new Product()
            {
                Id = 2,
                Name = "UPDATE NAME OF PRODUCT",
                Price = Convert.ToDecimal(15.99),
                Description = "A Caneca Stranger Things Chibi é um produto original e licenciado da Piticas. Feito para você expressar o seu lado fã da série Stranger Things. Ideal para presentear ou colecionar. Caneca de cerâmica - Altura: 14,5cm | Comprimento: 10cm | Largura: 9,5cm capacidade: 400ml",
                CategoryName = "Canecas",
                ImageUrl = "https://tfcprw.vtexassets.com/arquivos/ids/166882-800-auto?v=637976691643600000&width=800&height=auto&aspect=true"
            };

            //Act
            if (productReturn != null)
                productReturn = product;

            if (_nameOfProductAfterUpdate == productReturn.Name)
                isUpdated = true;

            ////Assert
            _outputHelper.WriteLine($"O produto atualizado foi: {_nameOfProductAfterUpdate}");
            Assert.Contains(_nameOfProductAfterUpdate, productReturn.Name);
            return isUpdated;
        }

        [Theory]
        [InlineData(2)]
        bool IProduct.DeleteProduct(int id)
        {
            var isDeleted = false;
            //Arrange
            var listOfProducts = _productData.CreateProductArray();
            var productReturn = listOfProducts.Where(p => p.Id == id).FirstOrDefault();

            //Act
            if (productReturn != null)
            {
                foreach (var item in listOfProducts.ToList())
                {
                    if (item.Id == id)
                    {
                        listOfProducts.Remove(productReturn);
                    }
                }
            }

            if (_expectedNumberOfProductsAfterDelete == listOfProducts.Count)
                isDeleted = true;

            ////Assert
            _outputHelper.WriteLine($"O produto deletado foi: {_expectedNumberOfProductsAfterDelete}");
            Assert.Equal(expected: _expectedNumberOfProductsAfterDelete, actual: listOfProducts.Count);
            return isDeleted;
        }
    }
}

