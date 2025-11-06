
using System.Threading.Channels;

namespace ChannelWorkerService;

public class OcrJobPublisherService : BackgroundService
{
    private readonly ILogger<OcrJobPublisherService> _logger;
    private readonly Channel<string> _channel;

    private FileSystemWatcher _watcher;

    private readonly string _path = Path.Combine(AppContext.BaseDirectory, "input");

    public OcrJobPublisherService(ILogger<OcrJobPublisherService> logger, Channel<string> channel)
    {
        this._logger = logger;
        _channel = channel;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("OcrJobPublisherService started.");

        if (!Directory.Exists(_path)) 
            Directory.CreateDirectory(_path);

        _watcher = new FileSystemWatcher(_path)
        {
            EnableRaisingEvents = true, // bardzo wazne!
            IncludeSubdirectories = false,
            Filter = "*.png",
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime,
        };

        _watcher.Created += async (s, e) =>
        {
            _logger.LogInformation("Wykryto nowy plik {FullPath}", e.FullPath);

            // Czekamy na zakonczenie zapisu
            await Task.Delay(3000);          

            await _channel.Writer.WriteAsync(e.FullPath); // Zapis do kanalu
        };

        _logger.LogInformation("Monitorowanie folderu: {path}", _path);

        return Task.CompletedTask;
    }
}
