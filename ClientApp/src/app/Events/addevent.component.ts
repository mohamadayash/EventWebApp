import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import dxFileUploader from 'devextreme/ui/file_uploader';
import { EventService } from '../Services/event.service';
import notify from 'devextreme/ui/notify';
import { Router } from '@angular/router';


@Component({
  selector: 'app-addevent',
  templateUrl: './addevent.component.html',
  styleUrls: ['./addevent.component.css']
})
export class AddEventComponent {


  @ViewChild('fileUploader') fileUploader:dxFileUploader
  files:any;
  
  eventForm = new FormGroup({
    eventTitle: new FormControl(),
    eventDate: new FormControl(),
    file:new FormControl()
  });

  constructor(private eventService:EventService,private router: Router) {

  }



  onValueChange(event:any){
    this.files = event.value;
  }


  public saveEvent() {

    let filesToUpload : File[] = this.files;
    const formData = new FormData();
    
    if (filesToUpload!= undefined && filesToUpload.length > 0){
      Array.from(filesToUpload).map((file, index) => {
        return formData.append('files', file, file.name);
      });
    }

    formData.append('eventTitle',this.eventForm.get('eventTitle')?.value);
    formData.append('eventDate',this.eventForm.get('eventDate')?.value);

    this.eventService.saveEvent(formData).subscribe({
        next: (response) => {
          notify('Saved successfully.');
          this.router.navigate(['..']);
        },
        error: (error) => notify('Error in saving.'),
      });

  }

}
