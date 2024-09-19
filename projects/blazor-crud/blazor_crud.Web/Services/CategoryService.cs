using blazor_crud.Domain;

namespace blazor_crud.Web.Services
{
    public class CategoryService(IHttpClientFactory clientFactory)
    {
        public async Task<List<Category>> GetAllAsync()
        {
            var client = clientFactory.CreateClient(CorsConfig.CLIENT_NAME);

            var result = await client.GetFromJsonAsync<List<Category>>("/categories");

            return result ?? [];

        }


        public async Task PostAsync(Category category)
        {
            var client = clientFactory.CreateClient(CorsConfig.CLIENT_NAME);

            await client.PostAsJsonAsync("/categories", category);
        }
    }
}
