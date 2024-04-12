namespace CustomerSubmissionsWebAppExample.Models
{
    public enum CustomerSubmissionStatus
    {
        New = 1,
        Responded = 2,
        WaitingForResponse = 3,
        EndedByUser = 4,
        EndedByCustomer = 5,
        EndedAutomatically = 6,
    }
}
