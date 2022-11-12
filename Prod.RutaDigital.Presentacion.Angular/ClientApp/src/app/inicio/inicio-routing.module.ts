import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventosComponent } from './pages/eventos/eventos.component';
import { InicioComponent } from './pages/inicio/inicio.component';

export const InicioRoutes: Routes = [
  {
    path: '',
    component: InicioComponent,
  },
  {
    path: 'eventos',
    component: EventosComponent,
  },
  {
    path: 'eventos/:evento',
    component: EventosComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(InicioRoutes)],
  exports: [RouterModule],
})
export class InicioRoutingModule {}
