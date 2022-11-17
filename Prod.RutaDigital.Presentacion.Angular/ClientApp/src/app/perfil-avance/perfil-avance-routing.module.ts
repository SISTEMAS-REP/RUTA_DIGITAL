import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PerfilAvanceComponent } from './perfil-avance.component';

export const PerfilAvanceRoutes: Routes = [
  {
    path: '',
    component: PerfilAvanceComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(PerfilAvanceRoutes)],
  exports: [RouterModule],
})
export class PerfilAvanceRoutingModule {}
