import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PremiosCatalogoComponent } from './components/premios-catalogo/premios-catalogo.component';
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
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(PremiosRoutes)],
  exports: [RouterModule],
})
export class PremiosRoutingModule {}
