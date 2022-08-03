namespace MvcExample.Application.Services.Subiekt123.Dto
{
    public class ClientDto
    {
        public bool Favourite { get; init; }
        public string? Group { get; init; }
        public int Id { get; init; }
        public ClientKindDto Kind { get; init; }
        public string? Name { get; init; }
        public string? Tin { get; init; }
        public TinKindDto TinKind { get; init; }
        public AddressDto? Address { get; set; }
    }
}