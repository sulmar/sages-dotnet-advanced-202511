using SemaphoreExample;

Console.WriteLine("Hello, Process 2!");

FileProcessor fileProcessor = new FileProcessor();

for (int i = 0; i < 5; i++)
{
    Thread thread = new Thread(fileProcessor.WriteToFile);
    thread.Start(i);
}