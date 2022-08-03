using Newtonsoft.Json;
using ServiceOrdersExample.Example.ErrorDetails;
using ServiceOrdersExample.Example.Exceptions;
using ServiceOrdersExample.Example.Models;
using ServiceOrdersExample.Models;
using System.Net.Http.Json;
using System.Text;

namespace ServiceOrdersExample.Example
{
    public class ServiceOrdersAPIClient
    {
        private const string _serviceOrdersAPIEndpoint = "https://api.insert.com.pl/";
        private string _serviceOrdersAPISubscriptionKey;

        public ServiceOrdersAPIClient(string subscriptionKey)
        {
            _serviceOrdersAPISubscriptionKey = subscriptionKey;
        }

        #region Dodanie zlecenia serwisowego

        /// <summary>
        /// Dodaje nowe zgłoszenie serwisowe
        /// </summary>
        /// <param name="serviceRegistration">Zgłoszenie serwisowe</param>
        /// <returns></returns>
        /// <exception cref="ValidationException">Wyjątek mówiący o wystąpieniu błędów walidacji danych wysłanych na serwer</exception>
        /// <exception cref="ServiceOrderApiException">Wyjątek mówiący o wystąpieniu nieznanego błędu podczas komunikacji z API zleceń serwisowych online</exception>
        /// <exception cref="UnauthorizedException">Wyjątek mówiący o nieautoryzowanej próbie dostępu do API</exception>
        public async Task<string> AddNewServiceRegistration(ServiceRegistration serviceRegistration)
        {
            HttpRequestMessage request = GetUploadServiceRegistrationRequest(serviceRegistration);
            HttpResponseMessage response = await SendHttpRequestToServiceOrdersAPIAsync(request);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        var uploadServiceRegistrationResponse = await GetUploadServiceRegistrationResponseAsync(response);
                        var urlIdZgloszenia = uploadServiceRegistrationResponse.ServiceRegistrationUrlId;
                        return urlIdZgloszenia;
                    }
                case System.Net.HttpStatusCode.BadRequest:
                    {
                        if (TryGetValidationProblemDetails(response, out ValidationProblemDetails errorDetails)) // próba pobrania informacji o blędach walidacji danych
                        {
                            throw new ValidationException(errorDetails);
                        }
                        else
                        {
                            throw new ServiceOrderApiException();
                        }
                    }
                case System.Net.HttpStatusCode.Unauthorized:
                    {
                        throw new UnauthorizedException();
                    }
                default:
                    {
                        throw new ServiceOrderApiException();
                    };
            }
        }

        /// <summary>
        /// Tworzy żądanie dodania zgłoszenia serwisowego
        /// </summary>
        /// <param name="serviceRegistration">Zgłoszenie serwisowe</param>
        /// <returns>Żądanie HTTP</returns>
        private HttpRequestMessage GetUploadServiceRegistrationRequest(ServiceRegistration serviceRegistration)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, $"serviceorders/1.0/serviceRegistration")
            {
                Content = PrepareContent(serviceRegistration),
            };

            message.Headers.Add("Ocp-Apim-Subscription-Key", _serviceOrdersAPISubscriptionKey); // nagłówek wymagany do autoryzowanego dostepu do API

            return message;
        }

        /// <summary>
        /// Pobiera id zgłoszenia serwisowego z odpowiedzi serwera na poprawnie dodane zlecenie serwisowse
        /// </summary>
        /// <param name="response">Odpowiedź serwera</param>
        /// <returns></returns>
        private async Task<UploadServiceRegistrationResponse> GetUploadServiceRegistrationResponseAsync(HttpResponseMessage response)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UploadServiceRegistrationResponse>(responseBody);
        }

        /// <summary>
        /// Pobiera informacje o błędach walidacji danyhch z odpowiedzi serwera
        /// </summary>
        /// <param name="response">Odpowiedź serwera</param>
        /// <param name="errorDetails">Otrzymane informacje o błędach</param>
        /// <returns>Informacja czy udało się pobrać dane o błędach walidacji</returns>
        private bool TryGetValidationProblemDetails(HttpResponseMessage response, out ValidationProblemDetails errorDetails)
        {
            try
            {
                errorDetails = response.Content.ReadFromJsonAsync<ValidationProblemDetails>().GetAwaiter().GetResult();
                return true;
            }
            catch
            {
                errorDetails = null;
                return false;
            }
        }

        /// <summary>
        /// Parsuje dane do pliku JSON
        /// </summary>
        /// <param name="body">Dane przesyłane w żądaniu http</param>
        /// <returns>Zawartość żądania HTTP</returns>
        private HttpContent PrepareContent(object body)
        {
            if (body != null)
            {
                string requestBody = JsonConvert.SerializeObject(body);
                return new StringContent(requestBody, Encoding.UTF8, "application/json");
            }

            return null;
        }
        #endregion

        #region Pobieranie zlecenia serwisowego
        /// <summary>
        /// Pobiera dane zlecenia serwisowego 
        /// </summary>
        /// <param name="serviceOrderUrlId">Id zlecenia serwisowego</param>
        /// <returns></returns>
        /// <exception cref="UnauthorizedException">Wyjątek mówiący o nieautoryzowanej próbie dostępu do API</exception>
        /// <exception cref="ForbiddenException">Wyjątek mówiący o odrzuceniu żądania przez API</exception>
        /// <exception cref="ServiceOrderNotFoundException">Wyjątek mówiący o braku zlecenia serwisowego o podanym Id na serwerze</exception>
        /// <exception cref="ServiceOrderApiException">Wyjątek mówiący o wystąpieniu nieznanego błędu podczas komunikacji z API zleceń serwisowych online</exception>
        public async Task<ServiceOrderWithHistory> GetServiceOrderWithHistory(string serviceOrderUrlId)
        {
            HttpRequestMessage request = CreateGetServiceOrderRequest(serviceOrderUrlId);
            HttpResponseMessage response = await SendHttpRequestToServiceOrdersAPIAsync(request);

            switch(response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    {
                        return await GetServiceOrderFromResponse(response);
                    }
                case System.Net.HttpStatusCode.Unauthorized:
                    {
                    throw new UnauthorizedException();
                }
                case System.Net.HttpStatusCode.Forbidden:
                    {
                    throw new ForbiddenException();
                }
                case System.Net.HttpStatusCode.NotFound:
                    {
                    throw new ServiceOrderNotFoundException();
                }
                default: 
                    {
                    throw new ServiceOrderApiException();
                }
            }
        }

        /// <summary>
        /// Tworzy żądanie pobrania zlecenia serwisowego
        /// </summary>
        /// <param name="urlIdZgloszenia">Id zgłoszenia zawarte we fragmencie adresu strony internetowej</param>
        /// <returns></returns>
        private HttpRequestMessage CreateGetServiceOrderRequest(string urlIdZgloszenia)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, $"/serviceorders/1.0/serviceOrder/{urlIdZgloszenia}");
            message.Headers.Add("Ocp-Apim-Subscription-Key", _serviceOrdersAPISubscriptionKey); // nagłówek wymagany do autoryzowanego dostepu do API

            return message;
        }

        /// <summary>
        /// Pobiera zlecenie serwisowe z odpowiedzi serwera
        /// </summary>
        /// <param name="response">Otrzymana odpowiedź od API</param>
        /// <returns>Dane zlecenia serwisowego z historią serwisowania</returns>
        private async Task<ServiceOrderWithHistory> GetServiceOrderFromResponse(HttpResponseMessage response)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ServiceOrderWithHistory>(responseBody);
        }
        #endregion

        /// <summary>
        /// Wysyła utworzone żądanie HTTP pod wskazany w appsettings.json adres API zleceń serwisowych online
        /// </summary>
        /// <param name="request">Wysyłane żądanie</param>
        /// <returns>Odpowiedź od serwera</returns>
        private async Task<HttpResponseMessage> SendHttpRequestToServiceOrdersAPIAsync(HttpRequestMessage request)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_serviceOrdersAPIEndpoint),
            };

            return await httpClient.SendAsync(request);
        }
    }
}
