using CustomerSubmissionsWebAppExample.Configuration;
using System.Text;
using System.Text.Json;

namespace CustomerSubmissionsWebAppExample.Client
{
    public class ApiClientBase
    {
        private readonly IAppSettings _appSettings;
        private HttpClient HttpClient { get; }

        public ApiClientBase(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings;
            HttpClient = httpClientFactory.CreateClient("customerSubmissionsApi");
        }

        protected async Task<T?> SendHttpRequestAndDeserializeResponse<T>(string url, HttpMethod httpMethod, object? content = null)
        {
            var request = new HttpRequestMessage(httpMethod, url);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _appSettings.SubscriptionKey);

            if (content != null)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
            }

            var response = await HttpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(responseContent, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        protected async Task SendHttpRequest(string url, HttpMethod httpMethod, object? content = null)
        {
            var request = new HttpRequestMessage(httpMethod, url);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _appSettings.SubscriptionKey);

            if (content != null)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
            }

            var response = await HttpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
