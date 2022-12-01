import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetalleRecomendacionComponent } from './pages/detalle-recomendacion/detalle-recomendacion.component';
import { TestAvanceComponent } from './pages/test-avance/test-avance.component';
import { RecomendacionesComponent } from './pages/recomendaciones/recomendaciones.component';
import { ErroresTestAvanceGuard } from './guards/errores-test-avance.guard';

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
  },
  {
    path: ':idRecomendacion/test',
    component: TestAvanceComponent,
    canActivate: [ErroresTestAvanceGuard]
  },
  
 
];

@NgModule({
  imports: [RouterModule.forChild(RecomendacionesRoutes)],
  exports: [RouterModule],
})
export class RecomendacionesRoutingModule {}
