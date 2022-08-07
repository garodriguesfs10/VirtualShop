using System.Net.Http.Headers;
using System.Text.Json;
using VShop.Web.Models;
using VShop.Web.Services.Contracts;

namespace VShop.Web.Services.Implementation
{
    public class CategoryService: ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string apiEndpoint = "/api/categories/";
        private readonly JsonSerializerOptions _options;
        private const string clientName = "ProductApi";
        private CategoryViewModel categoryVM;
        private IEnumerable<CategoryViewModel> categoriesVM;
        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories(string token)
        {
            var client = _httpClientFactory.CreateClient(clientName);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            using (var response = await client.GetAsync(apiEndpoint)) 
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync(); //serializa o conteudo http e retorna string
                    categoriesVM = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }

            return categoriesVM;
        }         
    }
}
