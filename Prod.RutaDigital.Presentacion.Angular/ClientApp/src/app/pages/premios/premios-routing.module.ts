import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PremiosComponent } from './premios.component';


export const PremiosRoutes: Routes = [
  { path: "", component: PremiosComponent },
  { path: "premios-catalogo", component: PremiosComponent, loadChildren: () => import("./components/premios-catalogo/premios-catalogo.module").then(m => m.PremiosCatalogoModule) },
  { path: "premios-detalle", component: PremiosComponent, loadChildren: () => import("./components/premios-detalle/premios-detalle.module").then(m => m.PremiosDetalleModule) },
  { path: "premios-listado", component: PremiosComponent, loadChildren: () => import("./components/premios-listado/premios-listado.module").then(m => m.PremiosListadoModule) },
];

@NgModule({
  imports: [RouterModule.forChild(PremiosRoutes)],
  exports: [RouterModule],
})
export class PremiosRoutingModule {}
