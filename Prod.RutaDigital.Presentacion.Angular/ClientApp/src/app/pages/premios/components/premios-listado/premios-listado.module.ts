import { LOCALE_ID,NgModule } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-owl-carousel-o';
import LocalES from '@angular/common/locales/es';
import { PremiosListadoComponent } from './premios-listado.component';
import { PremiosListadoRoutingModule } from './premios-listado-routing.module';
import { NgSelectModule } from '@ng-select/ng-select';
registerLocaleData(LocalES,'es')

@NgModule({
  declarations: [
    PremiosListadoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    PremiosListadoRoutingModule,
    CarouselModule,
    NgSelectModule
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'es' },
  ],

})
export class PremiosListadoModule {}