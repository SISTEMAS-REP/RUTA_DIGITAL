import { LOCALE_ID,NgModule } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InicioRoutingModule } from './inicio-routing.module';
import { InicioComponent } from './inicio.component';
import { RouterModule } from '@angular/router';
import { SeccionBannerPrincipalComponent } from './components/seccion-banner-principal/seccion-banner-principal.component';
import { SeccionCapacitacionComponent } from './components/seccion-capacitacion/seccion-capacitacion.component';
import { SeccionPremiosComponent } from './components/seccion-premios/seccion-premios.component';
import { SeccionEventosComponent } from './components/seccion-eventos/seccion-eventos.component';
import { SeccionBannerPieComponent } from './components/seccion-banner-pie/seccion-banner-pie.component';
import { CarouselModule } from 'ngx-owl-carousel-o';
import LocalES from '@angular/common/locales/es';
registerLocaleData(LocalES,'es')



@NgModule({
  declarations: [
    InicioComponent,
    SeccionBannerPrincipalComponent,
    SeccionCapacitacionComponent,
    SeccionPremiosComponent,
    SeccionEventosComponent,
    SeccionBannerPieComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    InicioRoutingModule,
    CarouselModule,
    
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'es' },
  ],

})
export class InicioModule {}
