using System.Collections.Generic;

namespace ServiceOrdersExample.Example.ErrorDetails
{
    public class ValidationProblemDetails
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int? Status { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }

        public Dictionary<string, IEnumerable<ValidationProblem>> Extensions { get; set; }
    }
}
