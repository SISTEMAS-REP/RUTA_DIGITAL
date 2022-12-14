import { LOCALE_ID,NgModule } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PremiosRoutingModule } from './premios-routing.module';
import { PremiosComponent } from './premios.component';
import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { GoogleMapsModule } from '@angular/google-maps'
import LocalES from '@angular/common/locales/es';
registerLocaleData(LocalES,'es')

@NgModule({
  declarations: [
    PremiosComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    PremiosRoutingModule,
    CarouselModule,
    GoogleMapsModule
    
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'es' },
  ],

})
export class PremiosModule {}