import { Post } from './../services/post';
import { Component, OnInit } from '@angular/core';

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

      console.log('sent to messagesservice');
      this.messageService.post(post)
        .subscribe(() => {
          this.message = '';
        });

    } else {
      this.snackBar.open('Felder <Username> und <Message> dürfen nicht leer sein!', 'Dammit!', {
        duration: 4000,
        panelClass: ['snackbar-failed']
      });
    }
  }

}
