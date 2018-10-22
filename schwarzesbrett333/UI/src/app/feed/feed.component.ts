import { SignalRService } from './../services/signalR.service';
import { MessageService } from './../services/messages.service';
import { Component, OnInit, NgZone } from '@angular/core';
import { Post } from '../services/post';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.scss']
})
export class FeedComponent implements OnInit {
  canSendMessage: boolean;
  currentPost: Post = new Post();
  // allPosts: Post[] = [];

  messages: Array<Post>;

  constructor(private messageService: MessageService, private signalRService: SignalRService, private ngZone: NgZone) {
    this.subscribeToEvents();
  }

  ngOnInit() {
    this.messageService.get()
      .subscribe(data => {
        this.messages = data,
          console.log(data);
        this.messages.forEach(message => {
          console.log(message.username, message.message);
        });
      });
  }
  subscribeToEvents(): void {
    this.signalRService.connectionEstablished.subscribe(() => {
      this.canSendMessage = true;
    });

    this.signalRService.postReceived.subscribe((post: Post) => {
      this.ngZone.run(() => {
        this.currentPost = new Post();
        this.messages.unshift(
          new Post(post.username, post.message, post.datum)
        );
      });
    });
  }


}
