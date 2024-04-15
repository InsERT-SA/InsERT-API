using CustomerSubmissionsWebAppExample.Models;

namespace CustomerSubmissionsWebAppExample.Client
{
    public interface ICustomerSubmissionClient
    {
        Task<CustomerSubmissionDto?> EndCustomerSubmission(string customerSubmissionUrlId);
        Task<CustomerSubmissionDto?> GetCustomerSubmission(string customerSubmissionUrlId);
        Task<MessagesDto?> GetMessages(string customerSubmissionUrlId);
        Task<UploadCustomerSubmissionResponseDto?> UploadCustomerSubmission(NewCustomerSubmissionDto customerSubmission);
        Task<UploadMessageResponseDto?> UploadMessage(string customerSubmissionUrlId, NewMessageDto message);
    }
}