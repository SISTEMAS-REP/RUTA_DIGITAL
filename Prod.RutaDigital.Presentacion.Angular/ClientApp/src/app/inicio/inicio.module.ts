import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { InicioRoutingModule } from './inicio-routing.module';
import { CarouselModule } from 'ngx-owl-carousel-o';
//import LocalES from '@angular/common/locales/es';
import { SeccionBannerPrincipalComponent } from './components/seccion-banner-principal/seccion-banner-principal.component';
import { SeccionCapacitacionComponent } from './components/seccion-capacitacion/seccion-capacitacion.component';
import { SeccionPremiosComponent } from './components/seccion-premios/seccion-premios.component';
import { SeccionEventosComponent } from './components/seccion-eventos/seccion-eventos.component';
import { SeccionBannerPieComponent } from './components/seccion-banner-pie/seccion-banner-pie.component';
import { InicioComponent } from './inicio.component';
//registerLocaleData(LocalES, 'es');

@NgModule({
  declarations: [
    InicioComponent,
    SeccionBannerPrincipalComponent,
    SeccionCapacitacionComponent,
    SeccionPremiosComponent,
    SeccionEventosComponent,
    SeccionBannerPieComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    InicioRoutingModule,
    CarouselModule
  ],
  //providers: [{ provide: LOCALE_ID, useValue: 'es' }],
})
export class InicioModule {}
