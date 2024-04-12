namespace CustomerSubmissionsWebAppExample.Configuration
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _configuration;

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;    
        }

        public string SubscriptionKey => _configuration[nameof(SubscriptionKey)] ?? string.Empty;
    }
}
