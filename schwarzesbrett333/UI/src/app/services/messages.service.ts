import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Post } from './post';


@Injectable({
  providedIn: 'root'
})
export class MessageService {
  constructor(private client: HttpClient, public snackBar: MatSnackBar) { }

    public get(): any {
      const url = 'https://localhost:5001/messages/';
      return this.client.get<Array<Post>>(url);
   }

   public post(post: any): Observable<any> {
    const url = 'https://localhost:5001/messages/';
    this.snackBar.open('Nachricht wird gepostet', 'Nice!', {
      duration: 4000,
      panelClass: ['snackbar-success']
    });
    return this.client.post(url, post);
   }
}

