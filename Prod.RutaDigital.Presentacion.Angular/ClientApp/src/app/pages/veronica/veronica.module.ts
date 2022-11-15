import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VeronicaComponent } from './veronica.component';
import { RouterModule } from '@angular/router';
import { AutodiagnosticoComponent } from './components/autodiagnostico/autodiagnostico.component';
import { VeronicaRoutingModule } from './veronica-routing.module';


@NgModule({
  declarations: [VeronicaComponent, AutodiagnosticoComponent],
  imports: [CommonModule, RouterModule, VeronicaRoutingModule],
})
export class VeronicaModule {}

