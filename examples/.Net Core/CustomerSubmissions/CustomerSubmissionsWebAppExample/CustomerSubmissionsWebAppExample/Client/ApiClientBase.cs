using CustomerSubmissionsWebAppExample.Configuration;
using System.Text;
using System.Text.Json;

namespace CustomerSubmissionsWebAppExample.Client
{
    public class ApiClientBase
    {
        private HttpClient HttpClient { get; }

        public ApiClientBase(
            IHttpClientFactory httpClientFactory)
        {
            HttpClient = httpClientFactory.CreateClient("customerSubmissionsApi");
        }

        protected async Task<T?> SendHttpRequestAndDeserializeResponse<T>(string url, HttpMethod httpMethod, object? content = null)
        {
            var request = new HttpRequestMessage(httpMethod, url);

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

            if (content != null)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
            }

            var response = await HttpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
