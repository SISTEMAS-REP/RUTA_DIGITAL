import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PremiosListadoComponent } from './premios-listado.component';

const routes: Routes = [
  { path: "", component:  PremiosListadoComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  declarations: [],
  exports: [RouterModule]
})
export class PremiosListadoRoutingModule { }