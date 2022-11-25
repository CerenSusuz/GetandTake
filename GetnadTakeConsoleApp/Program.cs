using GetandTake.Models.DTOs.ResponseDTO;
using System.Net.Http.Headers;

HttpClient client = new()
{
    BaseAddress = new Uri("https://localhost:7167/api")
};
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));

try
{
    List<ProductResponse> products = null;
    List<CategoryResponse> categories = null;
    var productsResponse = await client.GetAsync($"{client.BaseAddress}/products");
    var categoriesResponse = await client.GetAsync($"{client.BaseAddress}/categories");

    if (productsResponse.IsSuccessStatusCode)
    {
        products = await productsResponse.Content.ReadAsAsync<List<ProductResponse>>();
        Console.WriteLine("Products");
        foreach (var product in products)
        {
            Console.WriteLine($"ProductName:{product.ProductName}\n");
        }
    }


    if (categoriesResponse.IsSuccessStatusCode)
    {
        categories = await categoriesResponse.Content.ReadAsAsync<List<CategoryResponse>>();
        Console.WriteLine("Categories");
        foreach (var category in categories)
        {
            Console.WriteLine($"CategoryName:{category.CategoryName}\n");
        }
    }

}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
}

Console.ReadLine();