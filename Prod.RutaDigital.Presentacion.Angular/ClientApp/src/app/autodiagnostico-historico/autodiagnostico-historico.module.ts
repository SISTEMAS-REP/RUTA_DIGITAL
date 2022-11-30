import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { NgStepperModule } from 'angular-ng-stepper';

import { AutodiagnosticoHistoricoRoutingModule } from './autodiagnostico-historico-routing.module';
import { ResultadoAutodiagnosticoHistoricoComponent } from './pages/resultado-autodiagnostico/resultado-autodiagnostico-historico.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { NgCircleProgressModule } from 'ng-circle-progress';

@NgModule({
  declarations: [
    ResultadoAutodiagnosticoHistoricoComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    AutodiagnosticoHistoricoRoutingModule,
    CdkStepperModule,
    NgStepperModule,

    NgCircleProgressModule,

    SharedModule
  ],
})
export class AutodiagnosticoHistoricoModule {}
