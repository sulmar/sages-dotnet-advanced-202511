using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterlockedExample;

internal class MessageStats
{
    public int ReadCount { get; private set; }
    public int PendingCount { get; private set; }
    public int ProcessedCount { get; private set; }

    private MessageStats()
    {
        
    }

    // Singleton Pattern
    private static MessageStats _instance;
    public static MessageStats Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MessageStats();
            }
            
            return _instance;
        }
    }

    public void IncrementPending()
    {
        PendingCount++;
    }

    public void DecrementPending()
    {
        PendingCount--;
    }

    public void IncrementProcessedCount()
    {
        ProcessedCount++;
    }

}
