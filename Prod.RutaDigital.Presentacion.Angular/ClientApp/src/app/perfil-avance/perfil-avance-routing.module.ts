import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PerfilAvanceGuard } from './guards/perfil-avance.guard';
import { PerfilAvanceComponent } from './perfil-avance.component';

export const PerfilAvanceRoutes: Routes = [
  {
    path: '',
    component: PerfilAvanceComponent,
    canActivate: [PerfilAvanceGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(PerfilAvanceRoutes)],
  exports: [RouterModule],
})
export class PerfilAvanceRoutingModule {}
