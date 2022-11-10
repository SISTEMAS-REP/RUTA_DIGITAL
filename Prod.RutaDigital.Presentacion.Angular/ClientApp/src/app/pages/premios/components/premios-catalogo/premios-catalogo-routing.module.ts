import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PremiosCatalogoBannerComponent } from './components/premios-catalogo-banner/premios-catalogo-banner.component';
import { PremiosCatalogoComponent } from './premios-catalogo.component';

export const InicioRoutes: Routes = [
  {
    path: '',
    component: PremiosCatalogoComponent,
    children: [
      { path: '', redirectTo: '', pathMatch: 'full' },
      {
        path: 'premios-catalogo-banner',
        component: PremiosCatalogoBannerComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(InicioRoutes)],
  exports: [RouterModule],
})
export class PremiosCatalogoRoutingModule {}


