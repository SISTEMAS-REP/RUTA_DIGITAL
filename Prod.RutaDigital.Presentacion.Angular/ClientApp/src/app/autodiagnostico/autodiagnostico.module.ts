import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { NgStepperModule } from 'angular-ng-stepper';

import { AutodiagnosticoRoutingModule } from './autodiagnostico-routing.module';
import { ResultadoAutodiagnosticoComponent } from './pages/resultado-autodiagnostico/resultado-autodiagnostico.component';
import { TestAutodiagnosticoComponent } from './pages/test-autodiagnostico/test-autodiagnostico.component';
import { TestAutodiagnosticoPreguntasComponent } from './pages/test-autodiagnostico/components/test-autodiagnostico-pregunta/test-autodiagnostico-pregunta.component';
import { TestAutodiagnosticoModuloComponent } from './pages/test-autodiagnostico/components/test-autodiagnostico-modulo/test-autodiagnostico-modulo.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    ResultadoAutodiagnosticoComponent,

    TestAutodiagnosticoComponent,
    TestAutodiagnosticoPreguntasComponent,
    TestAutodiagnosticoModuloComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    AutodiagnosticoRoutingModule,
    CdkStepperModule,
    NgStepperModule,

    SharedModule
  ],
})
export class AutodiagnosticoModule {}
