using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceOrdersExample.Example;
using ServiceOrdersExample.Models;

namespace ServiceOrdersExample.Pages.ServiceOrders
{
    public class FormularzModel : PageModel
    {
        private readonly ServiceOrdersAPIClient _serviceOrdersAPIClient;

        [BindProperty]
        public Company? Company { get; set; }

        [BindProperty]
        public ServiceRegistration ServiceRegistration { get; set; }

        [BindProperty]
        public Device? Device { get; set; }

        public FormularzModel(ServiceOrdersAPIClient serviceOrdersAPIClient)
        {
            _serviceOrdersAPIClient = serviceOrdersAPIClient;

            ServiceRegistration = new ServiceRegistration()
            {
                IsCompany = true
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ServiceRegistration.Devices = new List<Device>() { Device };

            string serviceRegistrationUrlid = await _serviceOrdersAPIClient.AddNewServiceRegistration(ServiceRegistration); 

            return RedirectToPage("/ServiceOrdersPages/HistoriaZgloszenia", new { urlIdZgloszenia = serviceRegistrationUrlid });
        }
    }
}
