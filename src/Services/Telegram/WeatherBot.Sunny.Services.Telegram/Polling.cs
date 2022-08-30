using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeatherBot.Sunny.Services.Telegram.Abstractions;

namespace WeatherBot.Sunny.Services.Telegram;

public class Polling : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<Polling> _logger;

    public Polling(IServiceProvider serviceProvider, ILogger<Polling> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        _logger.LogInformation("Starting polling service");

        while (!ct.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var receiver = scope.ServiceProvider.GetRequiredService<IReceiver>();

                await receiver.ReceiveAsync(ct);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(Polling)} failed with exception: {ex}");

                await Task.Delay(TimeSpan.FromSeconds(5), ct);
            }
        }
    }
}