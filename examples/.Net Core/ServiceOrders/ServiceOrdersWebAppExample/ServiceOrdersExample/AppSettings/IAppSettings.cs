namespace ServiceOrdersExample
{
    public interface IAppSettings
    {
        string ServiceOrdersApiEndpoint { get; }
        string SubscriptionKey { get; }
    }
}
