import { LOCALE_ID,NgModule } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { GoogleMapsModule } from '@angular/google-maps'
import LocalES from '@angular/common/locales/es';
registerLocaleData(LocalES,'es')

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    CarouselModule,
    GoogleMapsModule
    
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'es' },
  ],

})
export class RecomendacionesModule {}
