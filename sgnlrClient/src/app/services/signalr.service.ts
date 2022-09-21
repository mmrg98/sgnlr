import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Customer } from '../_interfaces/customer.model';

@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  public customers: Customer[];
  private hubConnection: signalR.HubConnection;


  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7176/customer')
      .configureLogging(signalR.LogLevel.Information)
      .build();

      // this.registerOnEvents();
      this.hubConnection.start().catch(err => console.error("hhh",err.toString()))
  }

  // private registerOnEvents() {
  //     this.hubConnection.on('transfercustomerdata', (data) => {
  //     this.customers = data;
  //     console.log(data);
  //   });
  };
  // this.hubConnection
  //   .start()
  //   .then(() => console.log('Connection started'))
  //   .catch((err) => console.log('Error while starting connection: ' + err));

  // public addTransferCustomerDataListener = () => {
  //   this.hubConnection.on('transfercustomerdata', (data) => {
  //     this.data = data;
  //     console.log(data);
  //   });
  // };
// }
