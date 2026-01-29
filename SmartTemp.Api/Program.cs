using Microsoft.EntityFrameworkCore;
using SmartTemp.Application.Interfaces;
using SmartTemp.Infrastructure.Data;
using SmartTemp.Infrastructure.Services;
using SmartTemp.Api.BackgroundServices;
using SmartTemp.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("cors", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddSignalR();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=smarttemp.db"));

builder.Services.AddScoped<ITemperatureService, TemperatureService>();
builder.Services.AddScoped<IAlarmService, AlarmService>();

builder.Services.AddHostedService<TemperatureWorker>();

var app = builder.Build();

app.UseCors("cors");

// ❗ Şimdilik kapalı
// app.UseHttpsRedirection();

app.MapControllers();
app.MapHub<TemperatureHub>("/temperatureHub");

app.Run();
