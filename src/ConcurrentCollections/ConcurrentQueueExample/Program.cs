// See https://aka.ms/new-console-template for more information
using ConcurrentQueueExample;

Console.WriteLine("Hello, ConcurrentQueue!");


var ocrService = new OcrService();
var fileNames = new[] { "invoice1.pdf", "contract2.pdf", "scan3.pdf" };
bool running = true;

// Konsument
var consumer = Task.Run(() =>
{
    while (running)
    {
        ocrService.ProcessNext();
        Thread.Sleep(10);
    }
});

// Producenci – wiele równoległych "skanerów"
Parallel.For(0, 30, i =>
{
    var document = new OcrDocument
    {
        FileName = fileNames[i % fileNames.Length],
        SubmittedAt = DateTime.Now
    };

    ocrService.Submit(document);
    Thread.Sleep(Random.Shared.Next(1, 10)); // symulacja różnego tempa
});

Thread.Sleep(2000);
running = false;
consumer.Wait();