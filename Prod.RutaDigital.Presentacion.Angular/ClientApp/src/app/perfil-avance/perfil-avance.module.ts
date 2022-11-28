import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PerfilAvanceComponent } from './perfil-avance.component';
import { RouterModule } from '@angular/router';
import { PerfilAvanceRoutingModule } from './perfil-avance-routing.module';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { FormsModule } from '@angular/forms';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { NgStepperModule } from 'angular-ng-stepper';
import { NgCircleProgressModule } from 'ng-circle-progress';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [PerfilAvanceComponent],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    CdkStepperModule,
    NgStepperModule,

    NgCircleProgressModule,

    SharedModule,
    
    RouterModule, 
    PerfilAvanceRoutingModule,
    CarouselModule,
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),

  ],
})
export class PerfilAvanceModule {}
