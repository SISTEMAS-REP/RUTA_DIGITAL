import { LOCALE_ID,NgModule } from '@angular/core';
import { CommonModule, registerLocaleData } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CarouselModule } from 'ngx-owl-carousel-o';
import LocalES from '@angular/common/locales/es';
import { PremiosCatalogoRoutingModule } from './premios-catalogo-routing.module';
import { PremiosCatalogoComponent } from './premios-catalogo.component';
registerLocaleData(LocalES,'es')

@NgModule({
  declarations: [
    PremiosCatalogoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    PremiosCatalogoRoutingModule,
    CarouselModule
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'es' },
  ],

})
export class PremiosCatalogoModule {}