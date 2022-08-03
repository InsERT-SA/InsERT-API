using Newtonsoft.Json;
using ServiceOrdersExample.Example;
using ServiceOrdersExample.Example.ErrorDetails;
using ServiceOrdersExample.Example.Exceptions;
using ServiceOrdersExample.Example.Models;
using ServiceOrdersExample.Models;

string subscriptionKey = ""; // klucz dostępu otrzymany z konta insert

string serviceRegistrationId = null;
ServiceOrdersAPIClient client = new(subscriptionKey);

Console.ForegroundColor = ConsoleColor.Magenta;

#region Tworzenie przykładowych danych
Device device = new()
{
    Name = "Klimatyzator przenośny VIVAX Style",
    Symbol = "ACP09",
};

ServiceRegistration serviceRegistration = new()
{
    NIP = "8304531760",
    IsCompany = true,
    CompanyName = "ABC s.c.",
    FirstName = string.Empty,
    LastName = string.Empty,
    Street = "Polanka",
    HouseNumber = "12",
    FlatNumber = "6",
    Postcode = "54-365",
    City = "Wrocław",
    Email = "info@abc.pl",
    PhoneNumber = "123-123-123",
    Description = "Klimatyzator nie działa. Po włączeniu zasilania brak jakiejkolwiek reakcji.",
    Devices = new List<Device>() { device },
};
#endregion

#region Dodanie nowego zlecenia serwisowego

PrintServiceRegistrationJson(serviceRegistration);

try
{
    Console.WriteLine("Próba wysłania zlecenia serwisowego na serwer");
    serviceRegistrationId = await client.AddNewServiceRegistration(serviceRegistration);
    Console.WriteLine($"Dodanie nowego zlecenia serwisowego zakończyło się powodzeniem. Id zgłoszenia serwisowego: {serviceRegistrationId}\n"); 
}
catch (ValidationException exception)
{
    Console.WriteLine("Wysłane dane są niepoprawne");

    foreach (ValidationProblem error in exception.ValidationProblemDetails.Extensions.Values)
    {
        Console.WriteLine($"Nazwa pola: {error.FieldName}");
        Console.WriteLine($"Komunikat błędu: {error.ErrorMessage}");
    }
}
catch (UnauthorizedException)
{
    Console.WriteLine("Nieautoryzowany dostęp. Niepoprawny subscription key.");
}
catch
{
    Console.WriteLine("Podczas próby dodania nowego zlecenia serwisowego wystąpił nieoczekiwany błąd.");
}

if (serviceRegistrationId == null)
{
    return;
}
#endregion

#region Pobranie danych zlecenia serwisowego

ServiceOrderWithHistory serviceOrderWithHistory = null;

try
{
    Console.WriteLine($"Próba pobrania danych zlecenia serwisowego o id: {serviceRegistrationId}");
    serviceOrderWithHistory = await client.GetServiceOrderWithHistory(serviceRegistrationId);
    Console.WriteLine($"Pobranie zlecenia serwisowego o id: {serviceRegistrationId} zakończyło się powodzeniem.\n");

}
catch (UnauthorizedException)
{
    Console.WriteLine("Nieautoryzowany dostęp. Niepoprawny subscription key.");
}
catch (ForbiddenException)
{
    Console.WriteLine("Nieuprawniony dostęp do API");
}
catch (ServiceOrderNotFoundException)
{
    Console.WriteLine($"Nie udało się znaleźć zlecenia serwisowego o id {serviceRegistrationId}");
}
catch
{
    Console.WriteLine("Podczas próby dodania nowego zlecenia serwisowego wystąpił nieoczekiwany błąd.");
}

if (serviceOrderWithHistory == null)
{
    return;
}

PrintServiceOrderWithHistoryJson(serviceOrderWithHistory);
#endregion

#region Metody pomocnicze
void PrintServiceRegistrationJson(ServiceRegistration serviceRegistration)
{
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("Wysyłane dane zgłoszenia serwisowego w formacie JSON:");
    var json = JsonConvert.SerializeObject(serviceRegistration, Formatting.Indented);
    Console.WriteLine(json);

    Console.ForegroundColor = ConsoleColor.Magenta;
    
}

void PrintServiceOrderWithHistoryJson(ServiceOrderWithHistory serviceOrderWithHistory)
{
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("Odebrane dane zlecenia serwisowego w formacie JSON");
    var json = JsonConvert.SerializeObject(serviceOrderWithHistory, Formatting.Indented);
    Console.WriteLine(json);

    Console.ForegroundColor = ConsoleColor.Magenta;
}
#endregion





