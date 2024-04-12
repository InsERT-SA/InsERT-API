using CustomerSubmissionsWebAppExample.Models;

namespace CustomerSubmissionsWebAppExample.Extensions
{
    public static class CustomerSubmissionStatusExtensions
    {
        public static bool IsEnded(this CustomerSubmissionStatus status)
        {


            
            return status == CustomerSubmissionStatus.EndedAutomatically
                || status == CustomerSubmissionStatus.EndedByCustomer
                || status == CustomerSubmissionStatus.EndedByUser;
        }
    }
}
