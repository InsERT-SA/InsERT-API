using CustomerSubmissionsWebAppExample.Configuration;
using CustomerSubmissionsWebAppExample.Models;

namespace CustomerSubmissionsWebAppExample.Client
{
    public class CategoriesClient : ApiClientBase, ICategoriesClient
    {
        public CategoriesClient(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory) 
            : base(appSettings, httpClientFactory)
        {
        }

        public async Task<CategoriesDto?> GetCategories()
        {
            return await SendHttpRequestAndDeserializeResponse<CategoriesDto>("categories", HttpMethod.Get);
        }
    }
}
