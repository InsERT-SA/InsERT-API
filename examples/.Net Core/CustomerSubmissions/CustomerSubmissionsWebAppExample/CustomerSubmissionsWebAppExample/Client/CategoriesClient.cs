using CustomerSubmissionsWebAppExample.Models;

namespace CustomerSubmissionsWebAppExample.Client
{
    public class CategoriesClient(IHttpClientFactory httpClientFactory) : ApiClientBase(httpClientFactory), ICategoriesClient
    {
        public async Task<CategoriesDto?> GetCategories()
        {
            return await SendHttpRequestAndDeserializeResponse<CategoriesDto>("categories", HttpMethod.Get);
        }
    }
}
