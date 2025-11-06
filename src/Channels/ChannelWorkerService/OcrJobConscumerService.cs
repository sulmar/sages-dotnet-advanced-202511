
using System.Threading.Channels;

namespace ChannelWorkerService;

public class OcrJobConscumerService : BackgroundService
{
    private readonly ILogger<OcrJobConscumerService> _logger;
    private readonly Channel<string> _channel;

    public OcrJobConscumerService(ILogger<OcrJobConscumerService> logger, Channel<string> channel)
    {
        this._logger = logger;
        this._channel = channel;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("OcrJobConscumerService started.");

        await foreach(var filePath in _channel.Reader.ReadAllAsync(stoppingToken))
        {
            _logger.LogInformation("Przetwarzanie OCR pliku {filePath}", filePath);
            await Task.Delay(30_000);

            _logger.LogInformation("Przetworzono plik {filePath}", filePath);
        }

        _logger.LogInformation("OcrJobConscumerService finished.");



    }
}