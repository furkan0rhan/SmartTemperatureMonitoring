using SmartTemp.Application.Interfaces;
using SmartTemp.Domain.Entities;
using SmartTemp.Infrastructure.Data;

namespace SmartTemp.Infrastructure.Services;

public class AlarmService : IAlarmService
{
    private readonly AppDbContext _context;
    private const double Threshold = 80;

    public AlarmService(AppDbContext context)
    {
        _context = context;
    }

    public bool CheckAlarm(double temperature)
    {
        if (temperature > Threshold)
        {
            _context.AlarmLogs.Add(new AlarmLog
            {
                Temperature = temperature,
                CreatedAt = DateTime.UtcNow
            });

            _context.SaveChanges();
            return true;
        }

        return false;
    }
}
