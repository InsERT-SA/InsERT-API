using CustomerSubmissionsWebAppExample.Models;

namespace CustomerSubmissionsWebAppExample.Client
{
    public interface ICategoriesClient
    {
        Task<CategoriesDto?> GetCategories();
    }
}