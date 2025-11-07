using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentQueueExample;

public class OcrDocument
{
    public string FileName { get; set; }
    public DateTime SubmittedAt { get; set; }

    public override string ToString() => $"📄 {FileName} ({SubmittedAt:HH:mm:ss.fff})";
}


public class OcrService
{
    private readonly Queue<OcrDocument> _queue = new(); // ❌ NIEBEZPIECZNA

    public void Submit(OcrDocument document)
    {
        _queue.Enqueue(document); // ❗ Brak synchronizacji
        Console.WriteLine($"Dodano do OCR: {document}");
    }

    public void ProcessNext()
    {
        if (_queue.TryDequeue(out var document))
        {
            Console.WriteLine($"Rozpoczęto przetwarzanie: {document}");
            Thread.Sleep(100); // symulacja OCR
            Console.WriteLine($"Zakończono: {document.FileName}");
        }
    }
}