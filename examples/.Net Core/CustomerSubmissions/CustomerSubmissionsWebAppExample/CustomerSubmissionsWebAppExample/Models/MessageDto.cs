namespace CustomerSubmissionsWebAppExample.Models
{
    public class MessageDto
    {
        public bool IsFromCustomer { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Body { get; set; }
    }
}
