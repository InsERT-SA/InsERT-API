namespace ServiceOrdersExample.Models
{
    public class ServiceOrderWithHistory
    {
        public ServiceOrder ServiceOrder { get; set; }
        public IEnumerable<HistoricalEntry> HistoricalEntries { get; set; }
    }
}
