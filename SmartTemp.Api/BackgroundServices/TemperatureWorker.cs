using Microsoft.AspNetCore.SignalR;
using SmartTemp.Api.Hubs;
using SmartTemp.Application.Interfaces;

namespace SmartTemp.Api.BackgroundServices;

public class TemperatureWorker : BackgroundService
{
    private readonly ILogger<TemperatureWorker> _logger;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IHubContext<TemperatureHub> _hub;

    public TemperatureWorker(
        ILogger<TemperatureWorker> logger,
        IServiceScopeFactory scopeFactory,
        IHubContext<TemperatureHub> hub)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
        _hub = hub;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();

            var tempService = scope.ServiceProvider.GetRequiredService<ITemperatureService>();
            var alarmService = scope.ServiceProvider.GetRequiredService<IAlarmService>();

            var temp = tempService.GetCurrentTemperature();
            var isAlarm = alarmService.CheckAlarm(temp);

            _logger.LogInformation("Temp: {temp} Alarm: {alarm}", temp, isAlarm);

            await _hub.Clients.All.SendAsync("temperatureUpdate", temp, isAlarm);

            await Task.Delay(3000, stoppingToken);
        }
    }
}
