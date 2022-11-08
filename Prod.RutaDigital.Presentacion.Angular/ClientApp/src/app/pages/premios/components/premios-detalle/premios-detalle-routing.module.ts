import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PremiosDetalleComponent } from './premios-detalle.component';

const routes: Routes = [
  { path: "", component:  PremiosDetalleComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  declarations: [],
  exports: [RouterModule]
})
export class PremiosDetalleRoutingModule { }