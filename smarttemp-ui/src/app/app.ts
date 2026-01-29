import { Component, signal, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="container">
      <h1>🔥 Smart Temperature Monitor</h1>

      <div class="card" [class.alarm]="alarm()">
        <div class="temp">{{ temperature() }} °C</div>
        <div class="status">
          Durum:
          <span [class.red]="alarm()" [class.green]="!alarm()">
            {{ alarm() ? 'ALARM' : 'NORMAL' }}
          </span>
        </div>
      </div>

      <p class="connection" [class.connected]="connected()">
        {{ connected() ? '🟢 Bağlı' : '🔴 Bağlanıyor...' }}
      </p>
    </div>
  `,
  styles: [`
    .container {
      font-family: Arial, Helvetica, sans-serif;
      text-align: center;
      margin-top: 60px;
    }

    h1 {
      font-size: 2.5rem;
      margin-bottom: 30px;
    }

    .card {
      display: inline-block;
      padding: 40px 60px;
      border-radius: 16px;
      background: #f3f3f3;
      box-shadow: 0 10px 25px rgba(0,0,0,.1);
      transition: 0.3s;
    }

    .card.alarm {
      background: #ffe5e5;
      box-shadow: 0 0 30px rgba(255,0,0,.6);
      transform: scale(1.05);
    }

    .temp {
      font-size: 4rem;
      font-weight: bold;
    }

    .status {
      margin-top: 10px;
      font-size: 1.3rem;
    }

    .red { color: red; font-weight: bold; }
    .green { color: green; font-weight: bold; }

    .connection {
      margin-top: 20px;
      opacity: 0.7;
    }

    .connected {
      opacity: 1;
    }
  `]
})
export class App implements OnInit, OnDestroy {

  temperature = signal(0);
  alarm = signal(false);
  connected = signal(false);

  private hubConnection!: signalR.HubConnection;

  ngOnInit(): void {
    if (typeof window !== 'undefined') {
      this.hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5261/temperatureHub")
        .withAutomaticReconnect()
        .build();

      this.hubConnection.start()
        .then(() => {
          console.log('SignalR connected');
          this.connected.set(true);
        })
        .catch(err => console.error('SignalR error:', err));

      this.hubConnection.on('temperatureUpdate', (temp: number, isAlarm: boolean) => {
        this.temperature.set(temp);
        this.alarm.set(isAlarm);
      });
    }
  }

  ngOnDestroy(): void {
    this.hubConnection?.stop();
  }
}
