import { Post } from './post';
import { Injectable } from '@angular/core';

import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Subject } from 'rxjs';


@Injectable()
export class SignalRService {
    private hubConnection: HubConnection;
    postReceived = new Subject<Post>();
    connectionEstablished = new Subject<Boolean>();

    constructor() {
        this.createConnection();
        this.registerOnServerEvents();
        this.startConnection();
    }

    private createConnection() {
        this.hubConnection = new HubConnectionBuilder()
            .withUrl('https://schwarzesbrett.azurewebsites.net/messageHub')
            // .withUrl('https://localhost:5001/messageHub')
            .build();
    }

    private startConnection(): void {
        this.hubConnection
            .start()
            .then(() => {
                console.log('Hub connection started');
                this.connectionEstablished.next(true);
            })
            .catch(err => {
                console.log('Error while establishing connection, retrying...');
                setTimeout(this.startConnection(), 5000);
            });
    }

    private registerOnServerEvents(): void {
        this.hubConnection.on('Send', (data: any) => {
            this.postReceived.next(data);
            console.log('receivedData ', data);
        });
    }
}
