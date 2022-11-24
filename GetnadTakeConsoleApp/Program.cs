using System.Net.Http.Headers;

static void Main()
{
    RunAsync().GetAwaiter().GetResult();
}

static async Task RunAsync()
{

    HttpClient client = new()
    {
        BaseAddress = new Uri("https://localhost:7167/api")
    };
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

    try
    {
        var products = await client.GetAsync(client.BaseAddress + "/products");
        var categories = await client.GetAsync(client.BaseAddress + "/categories");

        if (products.IsSuccessStatusCode && categories.IsSuccessStatusCode)
        {
            Console.WriteLine($"Products : {products} / Categories {categories}");
        }      
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception.Message);
    }

    Console.ReadLine();
}