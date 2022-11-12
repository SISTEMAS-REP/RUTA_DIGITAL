import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { RecomendacionesRoutingModule } from './recomendaciones-routing.module';
import { RecomendacionesComponent } from './pages/recomendaciones/recomendaciones.component';
import { DetalleRecomendacionComponent } from './pages/detalle-recomendacion/detalle-recomendacion.component';
import { TestAvanceComponent } from './pages/test-avance/test-avance.component';

@NgModule({
  declarations: [
    RecomendacionesComponent,
    DetalleRecomendacionComponent,
    TestAvanceComponent,
  ],
  imports: [CommonModule, RouterModule, RecomendacionesRoutingModule],
})
export class RecomendacionesModule {}
