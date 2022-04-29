using MvcExample.Application.Services.InsertApiToken;
using MvcExample.Infrastructure.Extensions;

namespace MvcExample.Infrastructure.Authorization
{
    internal class InsertApiTokenService : IInsertApiTokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InsertApiTokenService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string?> GetAccessToken()
        {
            if (_httpContextAccessor.HttpContext == null)
                throw new InvalidOperationException("Missing access token.");

            return await _httpContextAccessor.HttpContext.GetAccessToken()
                ?? throw new InvalidOperationException("Missing access token.");
        }
    }
}