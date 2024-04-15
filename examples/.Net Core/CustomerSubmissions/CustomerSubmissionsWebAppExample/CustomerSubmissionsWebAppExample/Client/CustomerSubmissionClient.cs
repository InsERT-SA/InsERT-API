using CustomerSubmissionsWebAppExample.Configuration;
using CustomerSubmissionsWebAppExample.Models;

namespace CustomerSubmissionsWebAppExample.Client
{
    public class CustomerSubmissionClient : ApiClientBase, ICustomerSubmissionClient
    {
        public CustomerSubmissionClient(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory) 
            : base(appSettings, httpClientFactory)
        {
        }

        public async Task<CustomerSubmissionDto?> EndCustomerSubmission(string customerSubmissionUrlId)
        {
            return await SendHttpRequestAndDeserializeResponse<CustomerSubmissionDto>($"customerSubmission/end?customerSubmissionUrlId={customerSubmissionUrlId}", HttpMethod.Post);
        }

        public async Task<CustomerSubmissionDto?> GetCustomerSubmission(string customerSubmissionUrlId)
        {
            return await SendHttpRequestAndDeserializeResponse<CustomerSubmissionDto>($"customerSubmission?customerSubmissionUrlIdentifier={customerSubmissionUrlId}", HttpMethod.Get);
        }

        public async Task<MessagesDto?> GetMessages(string customerSubmissionUrlId)
        {
            return await SendHttpRequestAndDeserializeResponse<MessagesDto>($"messages?customerSubmissionUrlIdentifier={customerSubmissionUrlId}", HttpMethod.Get);
        }

        public async Task<UploadCustomerSubmissionResponseDto?> UploadCustomerSubmission(NewCustomerSubmissionDto customerSubmission)
        {
            return await SendHttpRequestAndDeserializeResponse<UploadCustomerSubmissionResponseDto>("customerSubmission", HttpMethod.Post, customerSubmission);
        }

        public async Task<UploadMessageResponseDto?> UploadMessage(string customerSubmissionUrlId, NewMessageDto message)
        {
            return await SendHttpRequestAndDeserializeResponse<UploadMessageResponseDto>($"message?customerSubmissionUrlId={customerSubmissionUrlId}", HttpMethod.Post, message);
        }
    }
}
