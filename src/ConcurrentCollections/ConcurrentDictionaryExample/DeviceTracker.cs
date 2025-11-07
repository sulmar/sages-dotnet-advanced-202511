using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentDictionaryExample;

public class DeviceStatus
{
    public string DeviceId { get; set; }
    public double BatteryLevel { get; set; }

    public override string ToString() => $"(ID: {DeviceId}) {BatteryLevel / 100:P2} ";    
}


public class DeviceTracker
{
    private readonly Dictionary<string, DeviceStatus> _devicesByImei = new(); // ❌ niebezpieczny słownik

    public bool TryGetDeviceStatus(string imei, out DeviceStatus status)
    {
        // ❗ Odczyt w czasie zapisu = potencjalny wyjątek
        return _devicesByImei.TryGetValue(imei, out status);
    }

    public void UpdateDeviceStatus(string imei, DeviceStatus status)
    {
        // równoczesne wywołania mogą spowodować wyjątek
        if (_devicesByImei.ContainsKey(imei))
        {
            _devicesByImei[imei] = status;
        }
        else
        {
            _devicesByImei.Add(imei, status);

        }

        ForceDictionaryEnumeration();

        Console.WriteLine($"Zaktualizowano: {imei} → {status}");

    }

    private void ForceDictionaryEnumeration()
    {
        // Zmusza do dotknięcia struktury
        foreach (var kv in _devicesByImei)
        {
            // nie robimy nic – sama enumeracja wystarczy,
            // żeby wywołać "Collection was modified" w czasie równoległych zapisów
        }
    }


    public void SimulateParallelUpdates()
    {
        string[] imeis = { "351111111111111", "352222222222222", "353333333333333" };

        Parallel.ForEach(imeis, imei =>
        {
            for (int i = 0; i < 10; i++)
            {
                var normalized = Random.Shared.NextDouble();         // 0.0 – 1.0
                var batteryLevel = 50 + normalized * 50;             // 50.0 – 100.0

                var status = new DeviceStatus
                {
                    DeviceId = $"dev-{imei[^3..]}",
                    BatteryLevel = batteryLevel
                };

                UpdateDeviceStatus(imei, status);

                Thread.Sleep(1); // sztuczne opóźnienie
            }
        });

        Console.WriteLine($"\nFinalnie zarejestrowano: {_devicesByImei.Count} urządzeń");
    }
}