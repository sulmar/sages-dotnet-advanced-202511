namespace MonitorExample;

internal class ConfigManager
{
    private readonly Dictionary<string, object> settings = new Dictionary<string, object>();




    protected ConfigManager()
    {

    }

    private static ConfigManager instance;

    public static ConfigManager Instance
    {
        get
        {
            if (instance == null)
            {
                Thread.Sleep(2000);

                instance = new();
            }


            return instance;
        }
    }

    private readonly object _syncLock = new object();

    public void Set(string key, object value)
    {
        Monitor.Enter(_syncLock);

        if (settings.ContainsKey(key))
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} set {key}");

            settings[key] = value;
        }
        else
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} add {key}");

            settings.Add(key, value);
        }

        // Monitor.Exit(_syncLock);    // zwalniamy blokade

    }

    public object Get(string key)
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} getting {key}");

        if (settings.ContainsKey(key))
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} getting {settings[key]}");

            return settings[key];
        }
        else
            return null;

    }
}
