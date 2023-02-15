
/* Critérios de aceite : 
 * 1. Criar produto com Id, Name, Price,Description,CategoryName,ImageUrl.
 * 2. As ações devem ser todas testadas : Pesquisar todos os produtos, Pesquisar um produto especifico, 
 *    Adicionar um produto, atualizar um produto, deletar um produto.
 * 3. Todos os campos são obrigatórios 
 */

using GeekShop.Tests.Interfaces;
using GeekShop.Tests.Models.ProductModel;
using Xunit.Abstractions;

namespace GeekShop.Tests
{
    public class ProductTests : IProduct
    {
        private const int _countOfList = 3;
        private const int _expectedNumberOfProductsAfterAdd = 4;
        private const int _expectedNumberOfProductsAfterDelete = 2;

        private const string _nameOfProductAfterUpdate = "NAME OF PRODUCT";

        private readonly ITestOutputHelper _outputHelper;

        public ProductTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        public List<Product> CreateProductArray()
        {
            List<Product> productTests = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "CANECA MULHER MARAVILHA: LAÇO DA VERDADE",
                    Price = Convert.ToDecimal(12.50),
                    Description = "Com essa caneca da Mulher Maravilha você poderá extrair o melhor de cada momento com quem você ama. Ideal para colecionar e presentear em grande estilo. Caneca Mulher Maravilha: Laço da Verdade. Material: Porcelana | Capacidade: 330ml | Tamanho: Altura: 10cm | Largura: 15cm",
                    CategoryName = "Canecas",
                    ImageUrl = "https://tfcprw.vtexassets.com/arquivos/ids/167379-800-auto?v=637976693564530000&width=800&height=auto&aspect=true"
                },
                 new Product
                {
                    Id = 2,
                    Name = "CANECA STRANGER THINGS CHIBI",
                    Price = Convert.ToDecimal(15.99),
                    Description = "A Caneca Stranger Things Chibi é um produto original e licenciado da Piticas. Feito para você expressar o seu lado fã da série Stranger Things. Ideal para presentear ou colecionar. Caneca de cerâmica - Altura: 14,5cm | Comprimento: 10cm | Largura: 9,5cm capacidade: 400ml",
                    CategoryName = "Canecas",
                    ImageUrl = "https://tfcprw.vtexassets.com/arquivos/ids/166882-800-auto?v=637976691643600000&width=800&height=auto&aspect=true"
                },
                  new Product
                {
                    Id = 3,
                    Name = "CANECA HARRY POTTER - POMO DE OURO",
                    Price = Convert.ToDecimal(16.99),
                    Description = "Perfeita para presentear e Decorar. Caneca Harry Potter - Pomo de Ouro. Altura:11,5cm. Largura:11cm. Capacidade:640 ml.",
                    CategoryName = "Canecas",
                    ImageUrl = "https://tfcprw.vtexassets.com/arquivos/ids/161601-800-auto?v=637976664368170000&width=800&height=auto&aspect=true"
                }
            };

            return productTests;
        }

        [Fact]
        List<Product> IProduct.GetProducts()
        {
            //Arrange
            var listOfProducts = new List<Product>();
            listOfProducts = CreateProductArray();

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
            var listOfProducts = CreateProductArray();

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
            var listOfProducts = CreateProductArray();
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
            var listOfProducts = CreateProductArray();
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
            var listOfProducts = CreateProductArray();
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

