namespace GeekShop.MockTest.Models
{
    public class GetProducts : IGetProducts
    {
        List<Product> IGetProducts.GetProducts()
        {
            CreateListOfProducts createListOfProducts = new CreateListOfProducts();
            var listOfProducts = createListOfProducts.CreateProductArray();

            if (listOfProducts.Count > 0)
                return listOfProducts;
            else
                return new List<Product>();
        }
    }
}
