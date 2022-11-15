import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AutodiagnosticoRoutingModule } from './autodiagnostico-routing.module';
import { AutodiagnosticoComponent } from './autodiagnostico.component';


@NgModule({
  declarations: [
    AutodiagnosticoComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    AutodiagnosticoRoutingModule,

  ],
})
export class AutoDiagnosticoModule {}
