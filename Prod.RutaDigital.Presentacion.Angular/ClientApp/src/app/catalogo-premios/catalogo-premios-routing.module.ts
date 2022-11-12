import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CatalogoPremiosComponent } from './catalogo-premios.component';
import { CategoriaPremiosComponent } from './pages/categoria-premios/categoria-premios.component';
import { InicioCatalogoPremiosComponent } from './pages/inicio-catalogo-premios/inicio-catalogo-premios.component';
import { DetallePremioComponent } from './pages/detalle-premio/detalle-premio.component';

export const CatalogoPremiosRoutes: Routes = [
  {
    path: '',
    component: CatalogoPremiosComponent,
    children: [
      {
        path: '',
        component: InicioCatalogoPremiosComponent,
      },
     
    ],
  },
  {
    path: 'categoria/:categoria',
    component: CategoriaPremiosComponent,
  },

  {
    path: 'premio/:premio',
    component: DetallePremioComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(CatalogoPremiosRoutes)],
  exports: [RouterModule],
})
export class CatalogoPremiosRoutingModule {}
