using BackgroundWorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<CustomWorker>(); // Worker musi implementowac interfejs IHostedService

var host = builder.Build();
host.Run();
