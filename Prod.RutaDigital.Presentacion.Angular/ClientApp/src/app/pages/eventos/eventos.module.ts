import { LOCALE_ID,NgModule } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EventosRoutingModule } from './eventos-routing.module';
import { EventosComponent } from './eventos.component';
import { RouterModule } from '@angular/router';
import { EventosSeleccionComponent } from './components/eventos-seleccion/eventos-seleccion.component';
import { CarouselModule } from 'ngx-owl-carousel-o';
import LocalES from '@angular/common/locales/es';
registerLocaleData(LocalES,'es')

@NgModule({
  declarations: [
    EventosComponent,
    EventosSeleccionComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    EventosRoutingModule,
    CarouselModule,
    
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'es' },
  ],

})
export class EventosModule {}
