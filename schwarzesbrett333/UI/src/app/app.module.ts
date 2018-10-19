import { SignalRService } from './services/signalR.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { MatButtonModule, MatCardModule, MatInputModule, MatToolbarModule, MatChipsModule, MatSnackBarModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { FeedComponent } from './feed/feed.component';
import { InputDialogComponent } from './input-dialog/input-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    FeedComponent,
    InputDialogComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatButtonModule,
    HttpClientModule,
    MatInputModule,
    MatToolbarModule,
    MatChipsModule,
    MatSnackBarModule
  ],
  providers: [ SignalRService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
