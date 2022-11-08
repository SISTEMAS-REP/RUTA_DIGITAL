import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PremiosCatalogoComponent } from './premios-catalogo.component';

const routes: Routes = [
  { path: "", component:  PremiosCatalogoComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  declarations: [],
  exports: [RouterModule]
})
export class PremiosCatalogoRoutingModule { }