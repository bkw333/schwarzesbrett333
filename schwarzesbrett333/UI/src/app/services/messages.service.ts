import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, observeOn, catchError } from 'rxjs/operators';
import { Post } from './post';


@Injectable({
  providedIn: 'root'
})
export class MessageService {
  url = 'https://schwarzesbrett.azurewebsites.net/messages';
  // url = 'https://localhost:5001/messages';
  constructor(private client: HttpClient, public snackBar: MatSnackBar) { }

    public get(): any {
      return this.client.get<Array<Post>>(this.url);
   }

   public post(post: any): Observable<any> {
    return this.client.post(this.url, post);
   }
}

