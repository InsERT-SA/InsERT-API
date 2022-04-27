using MvcExample.Application.Services.InsertApiToken;
using System.Net.Http.Headers;

namespace MvcExample.Infrastructure.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        public static async Task<HttpRequestMessage> WithBearerTokenAuthorization(this HttpRequestMessage httpRequestMessage, IInsertApiTokenService insertApiTokenService)
        {
            var accessToken = await insertApiTokenService.GetAccessToken();

            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            return httpRequestMessage;
        }

        public static HttpRequestMessage WithSubscriptionKeyHeader(this HttpRequestMessage httpRequestMessage, string subscriptionKey)
        {
            httpRequestMessage.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            return httpRequestMessage;
        }

        public static HttpRequestMessage WithAcceptApplicationJsonHeader(this HttpRequestMessage httpRequestMessage)
        {
            httpRequestMessage.Headers.Add("Accept", "application/json");

            return httpRequestMessage;
        }
    }
}
