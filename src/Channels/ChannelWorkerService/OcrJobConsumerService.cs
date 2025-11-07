
using System.Threading.Channels;

namespace ChannelWorkerService;

public class OcrJobConsumerService : BackgroundService
{
    private readonly ILogger<OcrJobConsumerService> _logger;
    private readonly Channel<string> _channel;

    public OcrJobConsumerService(ILogger<OcrJobConsumerService> logger, Channel<string> channel)
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