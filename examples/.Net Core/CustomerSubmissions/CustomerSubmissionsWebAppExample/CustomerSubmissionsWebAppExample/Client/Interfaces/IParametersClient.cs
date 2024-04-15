using CustomerSubmissionsWebAppExample.Models;

namespace CustomerSubmissionsWebAppExample.Client
{
    public interface IParametersClient
    {
        Task<CompanyParametersDto?> GetCompanyParameters();
        Task<FormConfigurationDto?> GetFormConfiguration();
    }
}