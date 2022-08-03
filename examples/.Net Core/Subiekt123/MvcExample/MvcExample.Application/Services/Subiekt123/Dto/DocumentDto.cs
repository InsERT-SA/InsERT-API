namespace MvcExample.Application.Services.Subiekt123.Dto
{
    public class DocumentDto
    {
        public string? Buyer { get; init; }
        public CalculationMethodDto CalculationMethod { get; init; }
        public string? Client { get; init; }
        public AddressDto? ClientAddress { get; init; }
        public string? ClientTin { get; init; }
        public string? Currency { get; init; }
        public DateTime? DeliveryDate { get; init; }
        public string? DocumentNumber { get; init; }
        public DateTime DueDate { get; init; }
        public int Id { get; init; }
        public DateTime IssueDate { get; init; }
        public string? Issuer { get; init; }
        public KindDto Kind { get; init; }
        public double? LeftToPay { get; init; }
        public PaymentStateDto PaymentState { get; init; }
        public DateTime? TaxLiabilityDate { get; init; }
        public double TotalGross { get; init; }
        public double TotalGrossPln { get; init; }
        public double TotalNet { get; init; }
        public double TotalNetPln { get; init; }
        public string? TransactionLocation { get; init; }
    }
}
