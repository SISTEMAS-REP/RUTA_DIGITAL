import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { TestAutodiagnosticoComponent } from './test-autodiagnostico.component';
import { TestAutoDiagnosticoRoutingModule } from './test-autodiagnostico-routing.module';
import { TestAutodiagnosticoPreguntasComponent } from './components/test-autodiagnostico-preguntas/test-autodiagnostico-preguntas.component';
import { TestAutodiagnosticoModuloComponent } from './components/test-autodiagnostico-modulo/test-autodiagnostico-modulo.component';

@NgModule({
  declarations: [
    TestAutodiagnosticoComponent,
    TestAutodiagnosticoPreguntasComponent,
    TestAutodiagnosticoModuloComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    TestAutoDiagnosticoRoutingModule,
    CarouselModule,
  ],
})
export class TestAutoDiagnosticoModule {}
