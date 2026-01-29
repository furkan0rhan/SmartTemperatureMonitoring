namespace SmartTemp.Application.Interfaces;

public interface IAlarmService
{
    bool CheckAlarm(double temperature);
}
