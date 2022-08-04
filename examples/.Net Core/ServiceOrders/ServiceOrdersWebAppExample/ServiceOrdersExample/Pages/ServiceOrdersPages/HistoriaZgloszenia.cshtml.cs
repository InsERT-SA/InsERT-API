using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceOrdersExample.Example;
using ServiceOrdersExample.Models;

namespace ServiceOrdersExample.Pages.ServiceOrders
{
    public class HistoriaZgloszeniaModel : PageModel
    {
        private readonly ServiceOrdersAPIClient _serviceOrdersAPIClient;

        public ServiceOrder ServiceOrder { get; set; }
        public Company Company { get; set; }
        public Device Device { get; set; }
        public IEnumerable<HistoricalEntry> HistoricalEntries { get; set; }

        public HistoriaZgloszeniaModel(ServiceOrdersAPIClient serviceOrdersAPIClient)
        {
            _serviceOrdersAPIClient = serviceOrdersAPIClient;
        }

        public async Task<IActionResult> OnGet(string urlIdZgloszenia)
        {
            ServiceOrderWithHistory serviceOrderWithHistory = await _serviceOrdersAPIClient.GetServiceOrderWithHistory(urlIdZgloszenia);

            ServiceOrder = serviceOrderWithHistory.ServiceOrder;
            Company = serviceOrderWithHistory.ServiceOrder.Company;
            Device = serviceOrderWithHistory.ServiceOrder.Devices.FirstOrDefault();
            HistoricalEntries = serviceOrderWithHistory.HistoricalEntries.OrderByDescending(x => x.CreationDate);

            return Page();
        }
    }
}
