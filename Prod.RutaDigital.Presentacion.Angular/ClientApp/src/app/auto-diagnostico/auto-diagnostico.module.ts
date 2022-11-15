import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { AutoDiagnosticoComponent } from './auto-diagnostico.component';
import { AutoDiagnosticoRoutingModule } from './auto-diagnostico-routing.module';
import { ResultadoAutodiagnosticoComponent } from './pages/resultado-autodiagnostico/resultado-autodiagnostico.component';

@NgModule({
  declarations: [
    AutoDiagnosticoComponent,
    ResultadoAutodiagnosticoComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    AutoDiagnosticoRoutingModule,
    CarouselModule,
  ],
})
export class AutoDiagnosticoModule {}
