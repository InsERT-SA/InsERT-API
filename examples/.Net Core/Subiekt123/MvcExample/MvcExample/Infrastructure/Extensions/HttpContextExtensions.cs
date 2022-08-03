using Microsoft.AspNetCore.Authentication;

namespace MvcExample.Infrastructure.Extensions
{
    internal static class HttpContextExtensions
    {
        public static string AccessTokenKey = "access_token";
        public static string RefreshTokenKey = "refresh_token";
        public static string ExpiresAtKey = "expires_at";

        public static async Task<string?> GetAccessToken(this HttpContext? httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));

            return await httpContext.GetTokenAsync(AccessTokenKey)
                ?? throw new InvalidOperationException("Missing access token.");
        }

        public static bool IsAuthenticated(this HttpContext httpContext)
        {
            return httpContext.User.Identity?.IsAuthenticated ?? false;
        }
    }
}