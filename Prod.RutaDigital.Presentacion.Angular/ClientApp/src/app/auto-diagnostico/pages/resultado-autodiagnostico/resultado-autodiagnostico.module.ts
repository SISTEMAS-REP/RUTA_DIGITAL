import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { ResultadoAutodiagnosticoComponent } from './resultado-autodiagnostico.component';
import { ResultadoAutoDiagnosticoRoutingModule } from './resultado-autodiagnostico-routing.module';

@NgModule({
  declarations: [
    ResultadoAutodiagnosticoComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ResultadoAutoDiagnosticoRoutingModule,
    CarouselModule,
  ],
})
export class ResultadoAutoDiagnosticoModule {}
