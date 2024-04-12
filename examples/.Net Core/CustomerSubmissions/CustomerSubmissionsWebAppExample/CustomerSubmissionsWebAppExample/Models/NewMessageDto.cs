using System.ComponentModel.DataAnnotations;

namespace CustomerSubmissionsWebAppExample.Models
{
    public class NewMessageDto
    {
        public bool IsFromCustomer { get; set; }

        public string AuthorName { get; set; }

        [MaxLength(4000)]
        public string Body { get; set; }
    }
}
