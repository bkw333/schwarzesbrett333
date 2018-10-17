import { MessageService } from './../services/messages.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.css']
})
export class FeedComponent implements OnInit {

  constructor(private messageService: MessageService ) {}

  messages: Array<any>;
  ngOnInit() {
    this.messageService.get().subscribe(data => {
        this.messages = data,
        console.log(data);
      });
  }

}
