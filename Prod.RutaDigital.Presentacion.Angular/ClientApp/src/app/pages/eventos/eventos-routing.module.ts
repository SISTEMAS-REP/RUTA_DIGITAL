import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventosComponent } from './eventos.component';
import { EventosSeleccionComponent } from './components/eventos-seleccion/eventos-seleccion.component';



export const EventosRoutes: Routes = [
  {
    path: '',
    component: EventosComponent,
    children: [
      { path: '', redirectTo: '', pathMatch: 'full' },
      {
        path: 'eventos-seleccion',
        component: EventosSeleccionComponent,
      },
      
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(EventosRoutes)],
  exports: [RouterModule],
})
export class EventosRoutingModule {}
