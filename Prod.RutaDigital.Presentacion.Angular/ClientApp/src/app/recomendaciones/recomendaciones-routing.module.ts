import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecomendacionesComponent } from './pages/recomendaciones/recomendaciones.component';
import { DetalleRecomendacionComponent } from './pages/detalle-recomendacion/detalle-recomendacion.component';
import { TestAvanceComponent } from './pages/test-avance/test-avance.component';

export const RecomendacionesRoutes: Routes = [
  {
    path: '',
    component: RecomendacionesComponent,
  },
  {
    path: 'modulo/:modulo/recomendacion/:recomendacion',
    component: DetalleRecomendacionComponent,
  },
  {
    path: 'modulo/:modulo/recomendacion/:recomendacion/test-avance',
    component: TestAvanceComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(RecomendacionesRoutes)],
  exports: [RouterModule],
})
export class RecomendacionesRoutingModule {}
