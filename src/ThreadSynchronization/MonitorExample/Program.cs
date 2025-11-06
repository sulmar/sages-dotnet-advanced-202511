
using MonitorExample;

Console.WriteLine("Hello, Monitor!");

Parallel.Invoke(
         () => ConfigManager.Instance.Set("Key1", "John"),
         () => ConfigManager.Instance.Get("Key1"),
         () => ConfigManager.Instance.Set("Key2", "Bob"),
         () => ConfigManager.Instance.Get("Key2"),
         () => ConfigManager.Instance.Set("Key1", "Ann"),
         () => ConfigManager.Instance.Set("Key1", "Ann"),
         () => ConfigManager.Instance.Set("Key1", "Ann")
     );


Console.ReadLine();