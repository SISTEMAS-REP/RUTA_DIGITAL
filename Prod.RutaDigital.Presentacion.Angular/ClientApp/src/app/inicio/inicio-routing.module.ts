import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio.component';

export const InicioRoutes: Routes = [
  {
    path: '',
    component: InicioComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(InicioRoutes)],
  exports: [RouterModule],
})
export class InicioRoutingModule {}
