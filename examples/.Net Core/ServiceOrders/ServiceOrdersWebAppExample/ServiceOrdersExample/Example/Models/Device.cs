using ServiceOrdersExample.Properties;
using System.ComponentModel.DataAnnotations;

namespace ServiceOrdersExample.Models
{
    public class Device
    {
        [StringLength(maximumLength: 128, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [Display(Name = "Nazwa")]
        public string? Name { get; set; }

        public string? Symbol { get; set; }

        [StringLength(maximumLength: 128, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [Display(Name = "Numer seryjny")]
        public string? SerialNumber { get; set; }

        [StringLength(maximumLength: 128, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [Display(Name = "Producent")]
        public string? Manufacturer { get; set; }

        [StringLength(maximumLength: 128, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.StringOnlyMaxLengthAttribute))]
        [Display(Name = "Model")]
        public string? Model { get; set; }
    }
}
