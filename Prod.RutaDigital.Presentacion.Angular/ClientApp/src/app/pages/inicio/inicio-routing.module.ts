import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio.component';
import { SeccionBannerPrincipalComponent } from './components/seccion-banner-principal/seccion-banner-principal.component';
import { SeccionCapacitacionComponent } from './components/seccion-capacitacion/seccion-capacitacion.component';
import { SeccionPremiosComponent } from './components/seccion-premios/seccion-premios.component';
import { SeccionEventosComponent } from './components/seccion-eventos/seccion-eventos.component';
import { SeccionBannerPieComponent } from './components/seccion-banner-pie/seccion-banner-pie.component';



export const InicioRoutes: Routes = [
  {
    path: '',
    component: InicioComponent,
    children: [
      { path: '', redirectTo: '', pathMatch: 'full' },
      {
        path: 'seccion-banner-principal',
        component: SeccionBannerPrincipalComponent,
      },
      {
        path: 'seccion-capacitacion',
        component: SeccionCapacitacionComponent,
      } ,
      {
        path: 'seccion-premios',
        component: SeccionPremiosComponent,
      },
      {
        path: 'seccion-eventos',
        component: SeccionEventosComponent,
      },
      {
        path: 'seccion-banner-pie',
        component: SeccionBannerPieComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(InicioRoutes)],
  exports: [RouterModule],
})
export class InicioRoutingModule {}
