using ServiceOrdersExample.Properties;
using System.ComponentModel.DataAnnotations;

namespace ServiceOrdersExample.Models
{
    public class ServiceRegistration
    {
        [StringLength(10, MinimumLength = 10, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringConstantLengthAttribute))]
        public string? NIP { get; set; }
        
        public bool IsCompany { get; set; }

        [StringLength(maximumLength: 512, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [Display(Name = "Nazwa firmy")]
        public string? CompanyName { get; set; }

        [StringLength(maximumLength: 32, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [Display(Name = "Imię")]
        public string? FirstName { get; set; }

        [StringLength(maximumLength: 64, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [Display(Name = "Nazwisko")]
        public string? LastName { get; set; }

        [StringLength(maximumLength: 64, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [Display(Name = "Ulica")]
        public string? Street { get; set; }

        [StringLength(maximumLength: 10, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [Display(Name = "Nr domu")]
        public string? HouseNumber { get; set; }

        [StringLength(maximumLength: 10, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [Display(Name = "Nr lokalu")]
        public string? FlatNumber { get; set; }

        [StringLength(maximumLength: 10, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [Display(Name = "Kod pocztowy")]
        public string? Postcode { get; set; }

        [StringLength(maximumLength: 64, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [Display(Name = "Miejscowość")]
        public string? City { get; set; }

        [StringLength(maximumLength: 128, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [EmailAddress]
        public string? Email { get; set; }
        
        [RegularExpression(@"(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.PhoneAttribute))]
        [StringLength(maximumLength: 128, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [Display(Name = "Numer telefonu")]
        public string? PhoneNumber { get; set; }

        [StringLength(maximumLength: 4000, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [Display(Name = "Opis problemu")]
        public string? Description { get; set; }
     
        public IEnumerable<Device>? Devices { get; set; }
    }
}
