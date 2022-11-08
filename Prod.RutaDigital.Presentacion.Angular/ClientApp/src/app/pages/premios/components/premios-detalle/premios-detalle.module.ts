import { LOCALE_ID,NgModule } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-owl-carousel-o';
import LocalES from '@angular/common/locales/es';
import { PremiosDetalleComponent } from './premios-detalle.component';
import { PremiosDetalleRoutingModule } from './premios-detalle-routing.module';
registerLocaleData(LocalES,'es')

@NgModule({
  declarations: [
    PremiosDetalleComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    PremiosDetalleRoutingModule,
    CarouselModule
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'es' },
  ],

})
export class PremiosDetalleModule {}