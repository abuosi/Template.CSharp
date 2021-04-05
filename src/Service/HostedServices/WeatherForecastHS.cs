using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace Service.HostedServices
{
    public class CheckWeatherForecastHS : IHostedService
    {
        private readonly ILogger<CheckWeatherForecastHS> _logger;
        private int executionCount = 0;
        private Timer _timer;
        
        public CheckWeatherForecastHS(ILogger<CheckWeatherForecastHS> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CheckWeatherForecastHS Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));

            return Task.CompletedTask;
        }
        
        private void DoWork(object state)
        {
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);
        }        

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CheckWeatherForecastHS Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
        
        public void Dispose()
        {
            _timer?.Dispose();
        }        
    }
}