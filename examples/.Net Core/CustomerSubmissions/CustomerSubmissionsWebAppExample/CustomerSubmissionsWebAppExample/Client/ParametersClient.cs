using CustomerSubmissionsWebAppExample.Models;

namespace CustomerSubmissionsWebAppExample.Client
{
    public class ParametersClient(IHttpClientFactory httpClientFactory) : ApiClientBase(httpClientFactory), IParametersClient
    {
        public async Task<CompanyParametersDto?> GetCompanyParameters()
        {
            return await SendHttpRequestAndDeserializeResponse<CompanyParametersDto>($"companyParameters", HttpMethod.Get);
        }

        public async Task<FormConfigurationDto?> GetFormConfiguration()
        {
            return await SendHttpRequestAndDeserializeResponse<FormConfigurationDto>($"formConfiguration", HttpMethod.Get);
        }
    }
}
