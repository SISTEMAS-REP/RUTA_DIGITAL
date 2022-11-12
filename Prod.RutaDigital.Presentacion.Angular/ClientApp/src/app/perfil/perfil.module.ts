import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PerfilComponent } from './perfil.component';
import { RouterModule } from '@angular/router';
import { PerfilRoutingModule } from './perfil-routing.module';

@NgModule({
  declarations: [PerfilComponent],
  imports: [CommonModule, RouterModule, PerfilRoutingModule],
})
export class PerfilAvanceModule {}
