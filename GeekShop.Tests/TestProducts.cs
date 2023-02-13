
/* Critérios de aceite : 
 * 1. Criar produto com Id, Name, Price,Description,CategoryName,ImageUrl.
 * 2. As ações devem ser todas testadas : Pesquisar todos os produtos, Pesquisar um produto especifico, 
 *    Adicionar um produto, atualizar um produto, deletar um produto.
 * 3. Todos os campos são obrigatórios 
 */

using GeekShop.Tests.Models;

namespace GeekShop.Tests
{
    public class TestProducts
    {
        [Fact]
        public List<ProductTest> GetProducts()
        {
            //Organization


            //Action
            var listOfProducts = CreateProductArray();

            ////Assert
            return listOfProducts;
        }

        [Fact]
        public ProductTest GetProductById()
        {
            //Organization
            var listOfProducts = CreateProductArray();
            var id = 2;

            //Action
            var product = listOfProducts.FirstOrDefault(p => p.Id == id);

            ////Assert
            return product;
        }

        [Fact]
        public bool AddProduct()
        {
            var isAdded = false;
            //Organization
            ProductTest product = new ProductTest()
            {
                Id = 4,
                Name = "CANECA HELLO KITTY REDONDA",
                Price = Convert.ToDecimal(16.99),
                Description = "A Caneca da Hello Kitty redonda, foi desenvolvida pela Piticas para expressar o seu lado fã da Personagem. Feira em cerâmica possuí capacidade 300ml | Medida: 8,5cm x 13,cm x 8cm",
                CategoryName = "Canecas",
                ImageUrl = "https://tfcprw.vtexassets.com/arquivos/ids/162012-800-auto?v=637976666992800000&width=800&height=auto&aspect=true"
            };

            //Action
            var listOfProducts = CreateProductArray();
            if (listOfProducts.Count > 0)
                listOfProducts.Add(product);

            foreach (var item in listOfProducts)
            {
                if (item.Id == 4)
                {
                    isAdded = true;
                    return isAdded;
                }
            }

            ////Assert
            return isAdded;
        }

        [Fact]
        public bool UpdateProduct()
        {
            var isUpdated = false;
            var id = 2;

            //Organization
            var listOfProducts = CreateProductArray();
            var productReturn = listOfProducts.Where(p => p.Id == id).FirstOrDefault();

            ProductTest product = new ProductTest()
            {
                Id = 2,
                Name = "UPDATE TEST - CANECA STRANGER THINGS CHIBI",
                Price = Convert.ToDecimal(15.99),
                Description = "A Caneca Stranger Things Chibi é um produto original e licenciado da Piticas. Feito para você expressar o seu lado fã da série Stranger Things. Ideal para presentear ou colecionar. Caneca de cerâmica - Altura: 14,5cm | Comprimento: 10cm | Largura: 9,5cm capacidade: 400ml",
                CategoryName = "Canecas",
                ImageUrl = "https://tfcprw.vtexassets.com/arquivos/ids/166882-800-auto?v=637976691643600000&width=800&height=auto&aspect=true"
            };

            //Action
            if (productReturn != null)
            {
                productReturn = product;

                if (productReturn.Name.Contains("UPDATE TEST - "))
                {
                    isUpdated = true;
                }
            }

            ////Assert
            return isUpdated;
        }

        [Fact]
        public bool DeleteProduct()
        {
            var isDeleted = false;
            var id = 2;

            //Organization
            var listOfProducts = CreateProductArray();
            var productReturn = listOfProducts.Where(p => p.Id == id).FirstOrDefault();

            //Action
            if (productReturn != null)
            {
                foreach (var item in listOfProducts)
                {
                    if (item.Id == id)
                    {
                        listOfProducts.Remove(productReturn);
                        isDeleted = true;   
                    }
                }
            }

            ////Assert
            return isDeleted;
        }

        public List<ProductTest> CreateProductArray()
        {
            List<ProductTest> productTests = new List<ProductTest>()
            {
                new ProductTest
                {
                    Id = 1,
                    Name = "CANECA MULHER MARAVILHA: LAÇO DA VERDADE",
                    Price = Convert.ToDecimal(12.50),
                    Description = "Com essa caneca da Mulher Maravilha você poderá extrair o melhor de cada momento com quem você ama. Ideal para colecionar e presentear em grande estilo. Caneca Mulher Maravilha: Laço da Verdade. Material: Porcelana | Capacidade: 330ml | Tamanho: Altura: 10cm | Largura: 15cm",
                    CategoryName = "Canecas",
                    ImageUrl = "https://tfcprw.vtexassets.com/arquivos/ids/167379-800-auto?v=637976693564530000&width=800&height=auto&aspect=true"
                },
                 new ProductTest
                {
                    Id = 2,
                    Name = "CANECA STRANGER THINGS CHIBI",
                    Price = Convert.ToDecimal(15.99),
                    Description = "A Caneca Stranger Things Chibi é um produto original e licenciado da Piticas. Feito para você expressar o seu lado fã da série Stranger Things. Ideal para presentear ou colecionar. Caneca de cerâmica - Altura: 14,5cm | Comprimento: 10cm | Largura: 9,5cm capacidade: 400ml",
                    CategoryName = "Canecas",
                    ImageUrl = "https://tfcprw.vtexassets.com/arquivos/ids/166882-800-auto?v=637976691643600000&width=800&height=auto&aspect=true"
                },
                  new ProductTest
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
    }
}

