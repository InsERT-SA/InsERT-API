namespace ServiceOrdersExample
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _configuration;

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ServiceOrdersApiEndpoint => _configuration[nameof(ServiceOrdersApiEndpoint)];

        public string SubscriptionKey => _configuration[nameof(SubscriptionKey)];
    }
}
