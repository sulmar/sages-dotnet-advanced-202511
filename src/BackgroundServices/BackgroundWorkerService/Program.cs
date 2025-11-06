using BackgroundWorkerService;

var builder = Host.CreateApplicationBuilder(args);

// dotnet add package Microsoft.Extensions.Hosting.WindowsServices
//builder.Services.AddWindowsService(options =>
//{
//    options.ServiceName = ".NET Joke Service";
//});

// sc.exe create ... - polecenie do rejestracji uslugi windows

builder.Services.AddHostedService<CustomWorker>(); // Worker musi implementowac interfejs IHostedService

var host = builder.Build();
host.Run();
