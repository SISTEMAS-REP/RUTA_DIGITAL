import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetalleRecomendacionComponent } from './pages/detalle-recomendacion/detalle-recomendacion.component';
import { RecomendacionesComponent } from './pages/recomendaciones/recomendaciones.component';

export const RecomendacionesRoutes: Routes = [
  {
    path: '',
    component: RecomendacionesComponent,
  },
  {
    path: 'modulo/:idModulo',
    component: RecomendacionesComponent,
  },
  {
    path: 'detalle/:idCapacitacionResultado',
    component: DetalleRecomendacionComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(RecomendacionesRoutes)],
  exports: [RouterModule],
})
export class RecomendacionesRoutingModule {}
