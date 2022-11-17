import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PerfilAvanceComponent } from './perfil-avance.component';
import { RouterModule } from '@angular/router';
import { PerfilAvanceRoutingModule } from './perfil-avance-routing.module';

@NgModule({
  declarations: [PerfilAvanceComponent],
  imports: [CommonModule, RouterModule, PerfilAvanceRoutingModule],
})
export class PerfilAvanceModule {}
