using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Services.Implementation;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private const string apiEndpoint = "/api/products/";
    private readonly JsonSerializerOptions _options;
    private const string clientName = "ProductApi";
    private ProductViewModel productVM;
    private IEnumerable<ProductViewModel> productsVM;
    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProducts(string token)
    {
        var client = _httpClientFactory.CreateClient(clientName);

        PutTokenInHeaderAuthorization(token, client);

        using (var response = await client.GetAsync(apiEndpoint))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync(); //serializa o conteudo http e retorna string
                productsVM = await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }

        return productsVM;

    }

    private static void PutTokenInHeaderAuthorization(string token, HttpClient client)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<ProductViewModel> FindProductById(int productId, string token)
    {
        var client = _httpClientFactory.CreateClient(clientName);

        PutTokenInHeaderAuthorization(token, client);

        using (var response = await client.GetAsync(apiEndpoint + productId))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync(); //serializa o conteudo http e retorna string
                productVM = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }

        return productVM;
    }

    public async Task<ProductViewModel> CreateProduct(ProductViewModel product, string token)
    {
        var client = _httpClientFactory.CreateClient(clientName);

        PutTokenInHeaderAuthorization(token, client);

        var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

        using (var response = await client.PostAsync(apiEndpoint, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync(); //serializa o conteudo http e retorna string
                productVM = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }

        return productVM;
    }

    public async Task<ProductViewModel> UpdateProduct(ProductViewModel product, string token)
    {
        var client = _httpClientFactory.CreateClient(clientName);

        PutTokenInHeaderAuthorization(token, client);

        ProductViewModel productUpdated = new ProductViewModel();

        using (var response = await client.PutAsJsonAsync(apiEndpoint,  product))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync(); //serializa o conteudo http e retorna string
                productUpdated = await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
            }
            else
            {
                return null;
            }
        }

        return productUpdated;
    }

    public async Task<bool> DeleteProduct(int id, string token)
    {
        var client = _httpClientFactory.CreateClient(clientName);

        PutTokenInHeaderAuthorization(token, client);

        using (var response = await client.DeleteAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                return true;
            }          
        }

        return false;
    }

   

  
}
