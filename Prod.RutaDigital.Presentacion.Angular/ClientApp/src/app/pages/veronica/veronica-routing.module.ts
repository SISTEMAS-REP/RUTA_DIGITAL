import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AutodiagnosticoComponent } from './components/autodiagnostico/autodiagnostico.component';
import { AvanceComponent } from './components/avance/avance.component';
import { DetalleRecomendacionesComponent } from './components/detalle-recomendaciones/detalle-recomendaciones.component';
import { ModalsComponent } from './components/modals/modals.component';
import { RecomendacionesComponent } from './components/recomendaciones/recomendaciones.component';
import { TestAutodiagnosticoComponent } from './components/test-autodiagnostico/test-autodiagnostico.component';
import { TestAvanceComponent } from './components/test-avance/test-avance.component';
import { VeronicaComponent } from './veronica.component';
import { AuthorizeGuard } from '../../authorization/authorize.guard';



export const VeronicaRoutes: Routes = [
  {
    path: '',
    component: VeronicaComponent,
    children: [
      {
        path: 'counter',
        component: VeronicaComponent,
      },
      {
        path: 'autodiagnostico',
        component: AutodiagnosticoComponent,
        canActivate: [AuthorizeGuard],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(VeronicaRoutes)],
  exports: [RouterModule],
})
export class VeronicaRoutingModule {}
