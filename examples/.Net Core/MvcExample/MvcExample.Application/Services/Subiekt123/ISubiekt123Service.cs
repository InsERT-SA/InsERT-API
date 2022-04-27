using MvcExample.Application.Services.Subiekt123.Dto;

namespace MvcExample.Application.Services.Subiekt123
{
    public interface ISubiekt123Service
    {
        Task<IEnumerable<ClientDto>> GetClients(int pageNumber);
        Task<IEnumerable<DocumentDto>> GetDocuments(int pageNumber);
        Task<IEnumerable<ProductDto>> GetProducts(int pageNumber);
    }
}