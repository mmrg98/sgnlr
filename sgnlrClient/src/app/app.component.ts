import { Component, OnInit } from '@angular/core';
import { SignalRService } from './services/signalr.service';
import { HttpClient } from '@angular/common/http';
import { Customer } from './_interfaces/customer.model';
import { FormGroup } from '@angular/forms';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'snglr';

  public _hubConnection: HubConnection;
  customers: any = [];

  count = this.customers.length;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.count = this.customers.length;
    this._hubConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:7176/customer')
      .build();
    this._hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch((err) => console.log('Error while establishing connection :('));

      
    this._hubConnection.on('BroadcastCustumer', (c) => {
      this.count = c;
    });
    this.refreshList();
  }

  refreshList() {
    this.http.get('https://localhost:7176/api/customer').subscribe((data) => {
      this.customers = data;
      this.count = this.customers.length;
    });
    this.count = this.customers.length;
  }
}

//   customers: Customer[] = [];
//   constructor(
//     private readonly signalRService: SignalRService,
//     private readonly http: HttpClient
//   ) {}
//   ngOnInit() {
//     this.http
//       .get<Customer[]>('https://localhost:7176/api/customer')
//       .subscribe((customers) => (this.customers = customers));

//     // this.signalRService.startConnection();
//     // this.signalRService.addTransferCustomerDataListener();
//     // this.startHttpRequest();
//   }

//   // private startHttpRequest = () => {
//   //   this.http.get('https://localhost:7176/api/customer').subscribe((res) => {
//   //     console.log(res);
//   //   });
//   // };
// }
