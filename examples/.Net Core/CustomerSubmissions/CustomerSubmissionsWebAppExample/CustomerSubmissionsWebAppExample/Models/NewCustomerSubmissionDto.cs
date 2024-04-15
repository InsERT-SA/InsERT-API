using System.ComponentModel.DataAnnotations;

namespace CustomerSubmissionsWebAppExample.Models
{
    public class NewCustomerSubmissionDto
    {
        [MaxLength(256)]
        public string CustomerFullName { get; set; }

        [MaxLength(128)]
        public string Email { get; set; }

        [MaxLength(64)]
        public string PhoneNumber { get; set; }

        [MaxLength(256)]
        public string Subject { get; set; }

        [MaxLength(4000)]
        public string Content { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
