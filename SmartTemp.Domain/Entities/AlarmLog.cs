namespace SmartTemp.Domain.Entities;

public class AlarmLog
{
    public int Id { get; set; }
    public double Temperature { get; set; }
    public DateTime CreatedAt { get; set; }
}
