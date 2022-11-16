import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { ResultadoAutodiagnosticoComponent } from './resultado-autodiagnostico.component';
import { ResultadoAutoDiagnosticoRoutingModule } from './resultado-autodiagnostico-routing.module';
import { ResultadoDiagnosticoDetalleComponent } from './components/resultado-diagnostico-detalle/resultado-diagnostico-detalle.component';

@NgModule({
  declarations: [
    ResultadoAutodiagnosticoComponent,
    ResultadoDiagnosticoDetalleComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ResultadoAutoDiagnosticoRoutingModule,
    CarouselModule,
  ],
})
export class ResultadoAutoDiagnosticoModule {}
