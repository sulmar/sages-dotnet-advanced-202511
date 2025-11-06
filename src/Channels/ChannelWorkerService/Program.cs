using ChannelWorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<OcrProcessingService>();

var host = builder.Build();
host.Run();
