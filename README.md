# Smart Temperature Monitoring System

📌 **Real-Time Temperature Monitoring & Alarm System**  
.NET 8 + Angular 21 + SignalR + SQLite ile geliştirilmiş canlı veri uygulaması.

---

## 🚀 Özellikler

- 🔄 Gerçek zamanlı sıcaklık gösterimi
- 🚨 80°C üzeri alarm tespiti
- 📦 Arka planda çalışan sıcaklık üreticisi (BackgroundService)
- 📊 Alarm geçmişi veritabanında tutulur
- ⚡ SignalR ile frontend’e canlı veri yayını
- 💡 Angular 21 ile modern responsive arayüz
- 🧱 Clean Architecture (Domain / Application / Infrastructure / API)

---

## 🛠 Teknolojiler

| Katman | Teknoloji |
|--------|------------|
| Backend | .NET 8 |
| Realtime | SignalR |
| Veritabanı | SQLite (EF Core) |
| Frontend | Angular 21 |
| Mimari | Clean Architecture |

---

## 🚀 Kurulum & Çalıştırma

### Backend
Server: http://localhost:5261
`
cd SmartTemperatureMonitoring
dotnet build
dotnet ef database update -p SmartTemp.Infrastructure -s SmartTemp.Api
dotnet run --project SmartTemp.Api
 `
 
### Frontend
UI: http://localhost:4200
`
cd smarttemp-ui
npm install
ng serve
`
