using ChannelWorkerService;
using System.Threading.Channels;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton(Channel.CreateUnbounded<string>());

builder.Services.AddHostedService<OcrJobPublisherService>();
builder.Services.AddHostedService<OcrJobConscumerService>();

var host = builder.Build();
host.Run();
