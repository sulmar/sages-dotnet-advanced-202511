namespace BackgroundWorkerService
{
    public class CustomWorker : BackgroundService
    {
        private readonly ILogger<CustomWorker> logger;

        public CustomWorker(ILogger<CustomWorker> logger)
        {
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {            
            while (!stoppingToken.IsCancellationRequested)
            {
                // zla praktyka
                // logger.LogInformation($"Worker running at: {DateTimeOffset.Now}");

                // dobra praktyka
                logger.LogInformation("Worker running at: {Now}", DateTimeOffset.Now);

                await DoWorkAsync();

                await Task.Delay(1000);
            }
        }

        private Task DoWorkAsync()
        {            
            Console.WriteLine("Working...");


            return Task.CompletedTask;  // Analogia do Task.FromResult(void)
        }
    }
}
