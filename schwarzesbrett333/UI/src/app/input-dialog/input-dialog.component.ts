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


  constructor(private messageService: MessageService, public snackBar: MatSnackBar) { }

  ngOnInit() { }

  clickedPost(username: string, message: string): void {
    const post = new Post;
    post.username = username;
    post.message = message;

    if (username !== '' && message !== '') {
      this.messageService.post(post)
        .subscribe(response => console.log());
        
    } else {
      this.snackBar.open('Felder <Username> und <Message> dürfen nicht leer sein!', 'Dammit!', {
        duration: 4000,
        panelClass: ['snackbar-failed']
      });
    }
  }

}
