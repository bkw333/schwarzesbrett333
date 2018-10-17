import { Post } from './../services/post';
import { Component, OnInit } from '@angular/core';
import { MessageService } from '../services/messages.service';


@Component({
  selector: 'app-input-dialog',
  templateUrl: './input-dialog.component.html',
  styleUrls: ['./input-dialog.component.css']
})
export class InputDialogComponent implements OnInit {


  constructor(private messageService: MessageService) { }

  ngOnInit() { }

  clickedPost(username: string, message: string): void {
    const post = new Post;
    post.Username = username;
    post.Message = message;
    this.messageService.post(post)
      .subscribe(response => console.log(response));
  }

}
