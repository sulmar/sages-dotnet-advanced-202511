namespace SemaphoreExample;

public class FileProcessor
{
    public void WriteToFile(object id)
    {
        Console.WriteLine($"Process - Request {id} is waiting for the semaphore...");
        

        try
        {
            string message = $"Process - Request {id} writing...\n";
            File.AppendAllText("sharedfile.txt", message);
            Console.WriteLine($"Process - Request {id} has written to the file.");
            Thread.Sleep(1000); // Symulacja czasu przetwarzania
        }
        finally
        {
            Console.WriteLine($"Process - Request {id} is releasing the semaphore.");        
        }
    }
}
