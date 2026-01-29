using Microsoft.EntityFrameworkCore;
using SmartTemp.Domain.Entities;

namespace SmartTemp.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<AlarmLog> AlarmLogs => Set<AlarmLog>();
}
