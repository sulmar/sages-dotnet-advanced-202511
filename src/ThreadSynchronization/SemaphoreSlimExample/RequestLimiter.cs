namespace SemaphoreSlimExample;

internal class RequestLimiter
{
    public RequestLimiter(int maxConcurrentRequests)
    {

    }

    public void ProcessRequest(int requestId)
    {
        Console.WriteLine($"Request {requestId} is waiting to be processed.");


        try
        {
            Console.WriteLine($"Processing request {requestId}");
            // Simulate some work being done
            Thread.Sleep(2000);
        }
        finally
        {
            Console.WriteLine($"Request {requestId} is processed.");

        }
    }
}