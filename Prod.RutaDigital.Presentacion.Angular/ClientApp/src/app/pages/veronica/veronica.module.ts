import { LOCALE_ID,NgModule } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { VeronicaRoutingModule } from './veronica-routing.module';
import { VeronicaComponent } from './veronica.component';
import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-owl-carousel-o';
import LocalES from '@angular/common/locales/es';
registerLocaleData(LocalES,'es')


@NgModule({
  declarations: [
    VeronicaComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    VeronicaRoutingModule,
    CarouselModule,
    
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'es' },
  ],

})
export class VeronicaModule {}
