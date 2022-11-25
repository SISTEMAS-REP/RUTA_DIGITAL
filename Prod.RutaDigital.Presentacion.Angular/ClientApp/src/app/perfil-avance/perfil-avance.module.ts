import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PerfilAvanceComponent } from './perfil-avance.component';
import { RouterModule } from '@angular/router';
import { PerfilAvanceRoutingModule } from './perfil-avance-routing.module';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';

@NgModule({
  declarations: [PerfilAvanceComponent],
  imports: [
    CommonModule, 
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
