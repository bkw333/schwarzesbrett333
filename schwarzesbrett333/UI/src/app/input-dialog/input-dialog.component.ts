import { Post } from './../services/post';
import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators'

import { MessageService } from '../services/messages.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-input-dialog',
  templateUrl: './input-dialog.component.html',
  styleUrls: ['./input-dialog.component.scss']
})
export class InputDialogComponent implements OnInit {
  message: string;
  username: string;

  constructor(private messageService: MessageService, public snackBar: MatSnackBar) { }

  ngOnInit() { }

  clickedPost(): void {
    if (this.username && this.message) {
      const post = new Post;
      post.username = this.username;
      post.message = this.message;


      //if else => error

      this.messageService.post(post)
        .subscribe(x => {
          this.snackBar.open('Nachricht wird gepostet', 'Good!', {
            duration: 4000,
            panelClass: ['snackbar-success']
          });
        }, err => {
          console.error('err', err.status);
          if (err.status === 429) {
            this.snackBar.open('Do not spam, cheers!', 'OKAY!', {
              duration: 4000,
              panelClass: ['snackbar-failed']
            });
          } else {
            this.snackBar.open(err.status + ': ' + err.statusText, 'DAMMIT!', {
              duration: 4000,
              panelClass: ['snackbar-failed']
            });
          }
        });


    } else {
      this.snackBar.open('Felder <Username> und <Message> dürfen nicht leer sein!', 'Dammit!', {
        duration: 4000,
        panelClass: ['snackbar-failed']
      });
    }
  }

}
