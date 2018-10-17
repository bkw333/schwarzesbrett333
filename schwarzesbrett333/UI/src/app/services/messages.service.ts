import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class MessageService {
  constructor(private client: HttpClient) { }

    public get(): Observable<any> {
      const url = 'https://localhost:5001/messages/';
      return this.client.get<Array<any>>(url);
   }

   public post(post: any): Observable<any> {
    const url = 'https://localhost:5001/messages/';
    return this.client.post(url, post);

   }
}

