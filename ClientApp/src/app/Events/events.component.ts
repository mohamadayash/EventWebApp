import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import dxFileUploader from 'devextreme/ui/file_uploader';
import { EventService } from '../Services/event.service';
import notify from 'devextreme/ui/notify';
import { Router } from '@angular/router';
import dxDataGrid from 'devextreme/ui/data_grid';


@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventComponent {


  @ViewChild('fileUploader') fileUploader:dxFileUploader
  @ViewChild('gridContainer') grid:dxDataGrid

  
  files:any;
  events:any;
  
  eventForm = new FormGroup({
    eventTitle: new FormControl(),
    eventDate: new FormControl(),
    file:new FormControl()
  });

  constructor(private eventService:EventService,private router: Router) {
    eventService.getEvents().subscribe((result)=>{
      this.events = result;
    });
  }



  onValueChange(event:any){
    this.files = event.value;
  }


  public addEvent() {
    this.router.navigate(['add-event-component']);
  }

  public editEvent() {
    var grid:any = this.grid.instance;
    var selectedRows =grid.getSelectedRowsData();
    if (selectedRows.length > 0){
      var row = selectedRows[0];
      this.router.navigate(['edit-event-component'],row);
    }
  }

}
