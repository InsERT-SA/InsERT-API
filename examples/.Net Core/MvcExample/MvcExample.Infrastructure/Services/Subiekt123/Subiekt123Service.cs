using MvcExample.Application.Options;
using MvcExample.Application.Services.InsertApiToken;
using MvcExample.Application.Services.Subiekt123;
using MvcExample.Application.Services.Subiekt123.Dto;
using MvcExample.Infrastructure.Extensions;

namespace MvcExample.Infrastructure.Services.Subiekt123
{
    public class Subiekt123Service : ISubiekt123Service
    {
        private const int PageSize = 10;

        private readonly IInsertApiTokenService _insertApiTokenService;
        private readonly HttpClient _httpClient;
        private readonly Subiekt123ApiOptions _subiekt123ApiOptions;

        public Subiekt123Service(IInsertApiTokenService insertApiTokenService,
            HttpClient httpClient,
            Subiekt123ApiOptions subiekt123ApiOptions)
        {
            _insertApiTokenService = insertApiTokenService;
            _httpClient = httpClient;
            _subiekt123ApiOptions = subiekt123ApiOptions;
        }

        public async Task<IEnumerable<ClientDto>> GetClients(int pageNumber)
        {
            using var request = await new HttpRequestMessage(HttpMethod.Get, new Uri($"/1.0/clients?pageSize={PageSize}&pageNumber={pageNumber}", UriKind.Relative))
                .WithAcceptApplicationJsonHeader()
                .WithSubscriptionKeyHeader(_subiekt123ApiOptions.SubscriptionKey)
                .WithBearerTokenAuthorization(_insertApiTokenService);

            return await _httpClient.HandleWithContent<IEnumerable<ClientDto>>(request)
                ?? Enumerable.Empty<ClientDto>();
        }

        public async Task<IEnumerable<DocumentDto>> GetDocuments(int pageNumber)
        {
            using var request = await new HttpRequestMessage(HttpMethod.Get, new Uri($"/1.0/documents?pageSize={PageSize}&pageNumber={pageNumber}", UriKind.Relative))
                .WithAcceptApplicationJsonHeader()
                .WithSubscriptionKeyHeader(_subiekt123ApiOptions.SubscriptionKey)
                .WithBearerTokenAuthorization(_insertApiTokenService);

            return await _httpClient.HandleWithContent<IEnumerable<DocumentDto>>(request)
                ?? Enumerable.Empty<DocumentDto>();
        }

        public async Task<IEnumerable<ProductDto>> GetProducts(int pageNumber)
        {
            using var request = await new HttpRequestMessage(HttpMethod.Get, new Uri($"/1.0/products?pageSize={PageSize}&pageNumber={pageNumber}", UriKind.Relative))
                .WithAcceptApplicationJsonHeader()
                .WithSubscriptionKeyHeader(_subiekt123ApiOptions.SubscriptionKey)
                .WithBearerTokenAuthorization(_insertApiTokenService);

            return await _httpClient.HandleWithContent<IEnumerable<ProductDto>>(request)
                ?? Enumerable.Empty<ProductDto>();
        }
    }
}