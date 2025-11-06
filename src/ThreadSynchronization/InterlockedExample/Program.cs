
using InterlockedExample;

Console.WriteLine("Hello, Interlocked!");

Thread publisher = new Thread(Publisher);
Thread consumer = new Thread(Consumer);

publisher.Start();
consumer.Start();

while(publisher.IsAlive || MessageStats.Instance.PendingCount > 0)
{
    Console.WriteLine($"Pending: {MessageStats.Instance.PendingCount} Processed: {MessageStats.Instance.ProcessedCount}");
	Thread.Sleep(200);
}

publisher.Join(); // czeka na zakonczenie watku 
consumer.Join();


Console.WriteLine("Press Enter to exit.");
Console.ReadLine();


void Publisher()
{
	for (int i = 0; i < 1000; i++)
	{
		MessageStats.Instance.IncrementPending();
		Thread.Sleep(2); // symulacja publikacji
	}
}


void Consumer()
{
	while(MessageStats.Instance.ProcessedCount < 1000)
	{
		if (MessageStats.Instance.PendingCount > 0)
		{
			MessageStats.Instance.DecrementPending();
			MessageStats.Instance.IncrementProcessedCount();

            Thread.Sleep(3); // symulacja przetwarzania
		}
		else
		{
			Thread.Sleep(1);
		}
	}
}