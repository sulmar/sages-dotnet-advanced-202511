
namespace ChannelWorkerService;



public class OcrProcessingService : BackgroundService
{
    private readonly ILogger<OcrProcessingService> _logger;

    private FileSystemWatcher _watcher;

    private readonly string _path = Path.Combine(AppContext.BaseDirectory, "input");

    public OcrProcessingService(ILogger<OcrProcessingService> logger)
    {
        this._logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("OcrProcessingService started.");

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

            // TODO: Uzyj kanalu
            Console.WriteLine("OCR...");
            await Task.Delay(30_000);
        };

        _logger.LogInformation("Monitorowanie folderu: {path}", _path);

        return Task.CompletedTask;
    }
}

