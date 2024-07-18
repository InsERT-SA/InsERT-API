using System.Text.Json;

namespace MvcExample.Infrastructure.Extensions
{
    internal static class HttpResponseMessageExtensions
    {
        public static async Task<T?> HandleWithContent<T>(this HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage.IsSuccessStatusCode)
                return await GetContent<T>(httpResponseMessage);

            throw await HandleError(httpResponseMessage);
        }

        public static async Task<T?> GetContent<T>(this HttpResponseMessage httpResponseMessage)
        {
            var json = await httpResponseMessage.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static async Task<Exception> HandleError(this HttpResponseMessage httpResponseMessage)
        {
            var errorMessage = httpResponseMessage.Content != null
                ? await httpResponseMessage.Content.ReadAsStringAsync()
                : string.Empty;

            return new InvalidOperationException(errorMessage);
        }
    }
}