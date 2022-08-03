using Microsoft.AspNetCore.Mvc;
using MvcExample.Application.Services.Subiekt123;

namespace MvcExample.Controllers
{
    public class Subiekt123Controller : Controller
    {
        private readonly ISubiekt123Service _subiekt123Service;

        public Subiekt123Controller(ISubiekt123Service subiekt123Service)
        {
            _subiekt123Service = subiekt123Service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Clients(int pageNumber)
        {
            var clients = await _subiekt123Service.GetClients(0);

            return View(clients);
        }

        public async Task<IActionResult> Documents()
        {
            var documents = await _subiekt123Service.GetDocuments(0);

            return View(documents);
        }

        public async Task<IActionResult> Products()
        {
            var products = await _subiekt123Service.GetProducts(0);

            return View(products);
        }
    }
}