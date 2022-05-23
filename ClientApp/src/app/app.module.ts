import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DxButtonModule, DxDataGridModule, DxDateBoxModule, DxFileUploaderModule, DxTextBoxModule } from 'devextreme-angular';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventComponent } from './Events/events.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EventService } from './Services/event.service';
import { AddEventComponent } from './Events/addevent.component';
import { EditEventComponent } from './Events/editevent.component';

@NgModule({
  declarations: [
    AppComponent,
    EventComponent,
    AddEventComponent,
    EditEventComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DxDataGridModule,
    DxFileUploaderModule,
    DxButtonModule,
    DxTextBoxModule,
    DxDateBoxModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [EventService],
  bootstrap: [AppComponent]
})
export class AppModule { }
