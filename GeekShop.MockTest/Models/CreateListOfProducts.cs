namespace GeekShop.MockTest.Models
{
    public class CreateListOfProducts
    {
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
    }
}
