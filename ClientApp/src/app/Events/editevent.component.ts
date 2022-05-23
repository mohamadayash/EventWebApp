import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { HttpClient, HttpEventType, HttpErrorResponse } from '@angular/common/http';
import dxFileUploader from 'devextreme/ui/file_uploader';
import { EventService } from '../Services/event.service';
import notify from 'devextreme/ui/notify';
import { Router } from '@angular/router';


@Component({
  selector: 'app-editevent',
  templateUrl: './editevent.component.html',
  styleUrls: ['./editevent.component.css']
})
export class EditEventComponent {


  @ViewChild('fileUploader') fileUploader:dxFileUploader
  files:any;
  uploadedfiles:any;
  eventRfId:any;

  
  eventForm = new FormGroup({
    title: new FormControl(),
    eventDate: new FormControl(),
  });

  constructor(private eventService:EventService,private router: Router) {
    var navigation = this.router.getCurrentNavigation();
    if (navigation != undefined || navigation!=null){
      var row:any = navigation.extras;
      this.eventRfId = row.rfId;
      this.uploadedfiles = row.files;
      this.eventForm.patchValue(row);
    }
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

    formData.append('eventRfId',this.eventRfId);
    formData.append('eventTitle',this.eventForm.get('title')?.value);
    formData.append('eventDate',this.eventForm.get('eventDate')?.value);

    this.eventService.updateEvent(formData).subscribe({
        next: (response) => {
          notify('Saved successfully.');
          this.router.navigate(['..']);
        },
        error: (error) => notify('Error in saving.'),
      });

  }

}
