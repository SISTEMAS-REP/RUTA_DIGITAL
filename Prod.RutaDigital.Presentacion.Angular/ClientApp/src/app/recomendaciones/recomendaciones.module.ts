import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { NgStepperModule } from 'angular-ng-stepper';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';

import { RecomendacionesComponent } from './pages/recomendaciones/recomendaciones.component';
import { DetalleRecomendacionComponent } from './pages/detalle-recomendacion/detalle-recomendacion.component';
import { TestAvanceComponent } from './pages/test-avance/test-avance.component';
import { TestAvancePreguntaComponent } from 'src/app/recomendaciones/pages/test-avance/components/test-avance-pregunta/test-avance-pregunta.component';

import { RecomendacionesRoutingModule } from './recomendaciones-routing.module';
import { NgCircleProgressModule } from 'ng-circle-progress';
    
@NgModule({
    declarations: [
        RecomendacionesComponent,
        DetalleRecomendacionComponent,

        TestAvanceComponent,
        TestAvancePreguntaComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        RouterModule,
        RecomendacionesRoutingModule,
        CdkStepperModule,
        NgStepperModule,
        NgCircleProgressModule,
        SharedModule
    ]
})
export class RecomendacionesModule {}
