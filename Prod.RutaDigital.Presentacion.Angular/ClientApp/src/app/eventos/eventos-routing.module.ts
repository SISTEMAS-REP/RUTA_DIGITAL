import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventosComponent } from './eventos.component';

export const EventosRoutes: Routes = [
  {
    path: '',
    component: EventosComponent,
  },
  {
    path: ':evento',
    component: EventosComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(EventosRoutes)],
  exports: [RouterModule],
})
export class EventosRoutingModule {}
