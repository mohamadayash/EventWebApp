import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEventComponent } from './Events/addevent.component';
import { EditEventComponent } from './Events/editevent.component';
import { EventComponent } from './Events/events.component';

const routes: Routes = [
  { path: 'event-component', component: EventComponent },
  { path: 'add-event-component', component: AddEventComponent },
  { path: 'edit-event-component', component: EditEventComponent },
  { path: '',   redirectTo: '/event-component', pathMatch: 'full' }, 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
