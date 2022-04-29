using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MvcExample.Infrastructure.Extensions;
using MvcExample.Infrastructure.Options;
using System.Globalization;

namespace MvcExample.Infrastructure.Authorization
{
    internal class CustomCookieAuthEvents : CookieAuthenticationEvents
    {
        private readonly InsertApiOptions _insertApiOptions;
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomCookieAuthEvents(InsertApiOptions insertApiOptions,
            IHttpClientFactory httpClientFactory)
        {
            _insertApiOptions = insertApiOptions;
            _httpClientFactory = httpClientFactory;
        }

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            await base.ValidatePrincipal(context);

            var expiresAtString = context.Properties.GetTokenValue(HttpContextExtensions.ExpiresAtKey);

            if (!DateTime.TryParse(expiresAtString, out var expiresAt))
            {
                context.RejectPrincipal();

                return;
            }

            if (expiresAt.ToUniversalTime() >= DateTime.UtcNow)
                return;

            var cancellationToken = context.HttpContext.RequestAborted;
            var tokenClientOptions = new TokenClientOptions
            {
                Address = $"{_insertApiOptions.Authority}/connect/token",
                ClientId = _insertApiOptions.ClientId,
                ClientSecret = _insertApiOptions.ClientSecret
            };
            using var httpClient = _httpClientFactory.CreateClient();
            var tokenClient = new TokenClient(httpClient, tokenClientOptions);
            var refreshToken = context.Properties.GetTokenValue(HttpContextExtensions.RefreshTokenKey);
            var tokenResponse = await tokenClient.RequestRefreshTokenAsync(refreshToken, cancellationToken: cancellationToken).ConfigureAwait(false);

            if (tokenResponse.IsError)
            {
                context.RejectPrincipal();

                return;
            }

            var expirationValue = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn).ToString("o", CultureInfo.InvariantCulture);

            context.Properties.StoreTokens(new[]
            {
                new AuthenticationToken { Name = HttpContextExtensions.RefreshTokenKey, Value = tokenResponse.RefreshToken },
                new AuthenticationToken { Name = HttpContextExtensions.AccessTokenKey, Value = tokenResponse.AccessToken },
                new AuthenticationToken { Name = HttpContextExtensions.ExpiresAtKey, Value = expirationValue }
            });

            context.ShouldRenew = true;
        }
    }
}
