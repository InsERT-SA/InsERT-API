using CustomerSubmissionsWebAppExample.Configuration;
using CustomerSubmissionsWebAppExample.Models;

namespace CustomerSubmissionsWebAppExample.Client
{
    public class ParametersClient : ApiClientBase, IParametersClient
    {
        public ParametersClient(
            IAppSettings appSettings,
            IHttpClientFactory httpClientFactory) 
            : base(appSettings, httpClientFactory)
        {
        }

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
