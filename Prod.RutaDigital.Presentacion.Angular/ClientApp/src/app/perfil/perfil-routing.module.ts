import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PerfilComponent } from './perfil.component';

export const PerfilRoutes: Routes = [
  {
    path: '',
    component: PerfilComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(PerfilRoutes)],
  exports: [RouterModule],
})
export class PerfilRoutingModule {}
