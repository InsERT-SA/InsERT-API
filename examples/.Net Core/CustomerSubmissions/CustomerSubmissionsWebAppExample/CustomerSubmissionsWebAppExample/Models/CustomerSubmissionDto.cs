namespace CustomerSubmissionsWebAppExample.Models
{
    public class CustomerSubmissionDto
    {
        public string CustomerFullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Number { get; set; }
        public string UrlIdenfitier { get; set; }
        public string Content { get; set; }
        public CustomerSubmissionStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string? Category { get; set; }
    }
}
