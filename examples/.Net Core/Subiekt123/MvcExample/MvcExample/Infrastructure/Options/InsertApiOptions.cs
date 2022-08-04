namespace MvcExample.Infrastructure.Options
{
    public class InsertApiOptions
    {
        public string Authority { get; init; } = string.Empty;
        public string Issuer { get; init; } = string.Empty;
        public string ClientId { get; init; } = string.Empty;
        public string ClientSecret { get; init; } = string.Empty;
        public string ResponseType { get; init; } = string.Empty;
        public string[] Scopes { get; init; } = Array.Empty<string>();
    }
}