import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class EventService {

  constructor(private http: HttpClient) { }

  baseUrl:any='https://localhost:7288/';

  saveEvent(formData:any){
    return this.http.post(this.baseUrl + "Events", formData);
  }

  updateEvent(formData:any){
    return this.http.put(this.baseUrl + "Events", formData);
  }

  getEvents(){
    return this.http.get(this.baseUrl + "Events");
  }


}