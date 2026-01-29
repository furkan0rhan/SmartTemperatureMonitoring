using SmartTemp.Application.Interfaces;

namespace SmartTemp.Infrastructure.Services;

public class TemperatureService : ITemperatureService
{
    private static readonly Random _random = new();

    public double GetCurrentTemperature()
    {
        return Math.Round(_random.NextDouble() * 100, 2);
    }
}
