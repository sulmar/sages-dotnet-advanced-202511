using ChannelWorkerService;
using System.Net.Http.Headers;
using System.Threading.Channels;

var builder = Host.CreateApplicationBuilder(args);

// builder.Services.AddSingleton(Channel.CreateUnbounded<string>()); // kanal bez limitu ilosci wiadomosci

var options = new BoundedChannelOptions(10)
{
    FullMode = BoundedChannelFullMode.Wait,
    SingleWriter = false,
    SingleReader = false,
};

// builder.Services.AddSingleton(Channel.CreateBounded<string>(10)); // kanal z limitem ilosci wiadomosci

builder.Services.AddSingleton(Channel.CreateBounded<string>(options)); // kanal z limitem ilosci wiadomosci

builder.Services.AddHostedService<OcrJobPublisherService>();
builder.Services.AddHostedService<OcrJobConscumerService>();

var host = builder.Build();
host.Run();
