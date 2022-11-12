import { LOCALE_ID, NgModule } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { RouterModule } from '@angular/router';
import { InicioRoutingModule } from './inicio-routing.module';
import { InicioComponent } from './pages/inicio/inicio.component';
import { EventosComponent } from './pages/eventos/eventos.component';
import { CarouselModule } from 'ngx-owl-carousel-o';
//import LocalES from '@angular/common/locales/es';
import { SeccionBannerPrincipalComponent } from './pages/inicio/components/seccion-banner-principal/seccion-banner-principal.component';
import { SeccionCapacitacionComponent } from './pages/inicio/components/seccion-capacitacion/seccion-capacitacion.component';
import { SeccionPremiosComponent } from './pages/inicio/components/seccion-premios/seccion-premios.component';
import { SeccionEventosComponent } from './pages/inicio/components/seccion-eventos/seccion-eventos.component';
import { SeccionBannerPieComponent } from './pages/inicio/components/seccion-banner-pie/seccion-banner-pie.component';
import { EventosSeleccionComponent } from './pages/eventos/components/eventos-seleccion/eventos-seleccion.component';
import { GoogleMapsModule } from '@angular/google-maps';
//registerLocaleData(LocalES, 'es');

@NgModule({
  declarations: [
    InicioComponent,

    SeccionBannerPrincipalComponent,
    SeccionCapacitacionComponent,
    SeccionPremiosComponent,
    SeccionEventosComponent,
    SeccionBannerPieComponent,

    EventosComponent,

    EventosSeleccionComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    InicioRoutingModule,
    CarouselModule,

    GoogleMapsModule,
  ],
  //providers: [{ provide: LOCALE_ID, useValue: 'es' }],
})
export class InicioModule {}
