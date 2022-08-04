namespace MvcExample.Application.Services.InsertApiToken
{
    public interface IInsertApiTokenService
    {
        Task<string?> GetAccessToken();
    }
}