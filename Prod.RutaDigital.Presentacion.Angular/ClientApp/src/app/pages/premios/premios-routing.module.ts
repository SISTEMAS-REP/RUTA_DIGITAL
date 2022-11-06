import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PremiosCatalogoComponent } from './components/premios-catalogo/premios-catalogo.component';
import { PremiosDetalleComponent } from './components/premios-detalle/premios-detalle.component';
import { PremiosListadoComponent } from './components/premios-listado/premios-listado.component';
import { PremiosComponent } from './premios.component';


export const PremiosRoutes: Routes = [
  {
    path: '',
    component: PremiosComponent,
    children: [
      { path: '', redirectTo: '', pathMatch: 'full' },     
      {
        path: 'premios-catalogo',
        component: PremiosCatalogoComponent,
      }, 
      {
        path: 'premios-listado',
        component: PremiosListadoComponent,
      }, 
      {
        path: 'premios-detalle',
        component: PremiosDetalleComponent,
      }, 
      {
        path: 'premios-detalle/:id',
        component: PremiosDetalleComponent,
      }, 
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(PremiosRoutes)],
  exports: [RouterModule],
})
export class PremiosRoutingModule {}
