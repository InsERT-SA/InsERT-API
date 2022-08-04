namespace ServiceOrdersExample.Models
{
    public class ServiceOrder
    {
        public string Number { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Diagnosis { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public DateTime FilingDate { get; set; }
        public DateTime? ServiceStartDate { get; set; }
        public DateTime? ExpectedServiceFinishDate { get; set; }
        public DateTime? ServiceFinishDate { get; set; }
        public string ExpectedPrice { get; set; }
        public Company Company { get; set; }
        public IEnumerable<Device> Devices { get; set; }
    }
}
