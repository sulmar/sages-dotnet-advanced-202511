using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterlockedExample;

internal class MessageStats
{
    public int ReadCount { get; private set; }

    private int _pendingCount;
    public int PendingCount => _pendingCount;

    // back field
    private int _processedCount;
    public int ProcessedCount => _processedCount;

    private MessageStats()
    {
        Console.WriteLine("MessageStats initalized.");
    }


    private static object _syncLock = new object();

    // Singleton Pattern
    private static MessageStats _instance;
    public static MessageStats Instance
    {
        get
        {
            //  <-- t2
            lock (_syncLock) //   // <-- t1   
            {                                        // Monitor.Enter(_syncLock)
                if (_instance == null)    
                {
                    _instance = new MessageStats();
                }

                return _instance;
            }                                        // Monitor.Exit(_syncLock)
        }
    }

    public void IncrementPending()
    {
        Interlocked.Increment(ref _pendingCount);
    }

    public void DecrementPending()
    {
        Interlocked.Decrement(ref _pendingCount);
    }

    public void IncrementProcessedCount()
    {
       Interlocked.Increment(ref _processedCount);
    }

}
