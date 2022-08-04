namespace MvcExample.Application.Services.Subiekt123.Dto
{
    public class ProductDto
    {
        public string? CnCode { get; init; }
        public string? Currency { get; init; }
        public string? Description { get; init; }
        public bool Favourite { get; init; }
        public string? FiscalName { get; init; }
        public string? Group { get; init; }
        public int Id { get; init; }
        public IEnumerable<string>? JpkVatGroups { get; init; }
        public ProductKindDto Kind { get; init; }
        public string? Name { get; init; }
        public double NetPrice { get; set; }
        public string? Pkwiu { get; init; }
        public bool SubjectToSplitPayment { get; init; }
        public string? Unit { get; init; }
        public string? VatRate { get; init; }
    }
}
