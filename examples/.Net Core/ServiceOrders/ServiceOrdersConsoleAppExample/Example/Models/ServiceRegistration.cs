namespace ServiceOrdersExample.Example.Models
{
    public class ServiceRegistration
    {
        public string NIP { get; set; }
        public bool IsCompany { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public IEnumerable<Device> Devices { get; set; }
    }
}
