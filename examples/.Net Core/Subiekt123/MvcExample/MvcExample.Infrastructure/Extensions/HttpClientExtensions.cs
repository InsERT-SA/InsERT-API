namespace MvcExample.Infrastructure.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T?> HandleWithContent<T>(this HttpClient httpClient, HttpRequestMessage httpRequestMessage)
        {
            using var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.HandleWithContent<T>();
        }
    }
}