import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CatalogoPremiosRoutingModule } from './catalogo-premios-routing.module';
import { CatalogoPremiosComponent } from './catalogo-premios.component';
import { InicioCatalogoPremiosComponent } from './pages/inicio-catalogo-premios/inicio-catalogo-premios.component';
import { CategoriaPremiosComponent } from './pages/categoria-premios/categoria-premios.component';
import { DetallePremioComponent } from './pages/detalle-premio/detalle-premio.component';
import { CarouselModule } from 'ngx-owl-carousel-o';

@NgModule({
  declarations: [
    CatalogoPremiosComponent,
    InicioCatalogoPremiosComponent,
    CategoriaPremiosComponent,
    DetallePremioComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    CatalogoPremiosRoutingModule,
    CarouselModule,
  ],
})
export class CatalogoPremiosModule {}
