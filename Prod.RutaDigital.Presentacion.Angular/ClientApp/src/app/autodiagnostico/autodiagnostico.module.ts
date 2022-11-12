import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AutodiagnosticoRoutingModule } from './autodiagnostico-routing.module';
import { TestAutodiagnosticoComponent } from './pages/test-autodiagnostico/test-autodiagnostico.component';
import { AutodiagnosticoComponent } from './pages/autodiagnostico/autodiagnostico.component';

@NgModule({
  declarations: [TestAutodiagnosticoComponent, AutodiagnosticoComponent],
  imports: [CommonModule, RouterModule, AutodiagnosticoRoutingModule],
})
export class AutodiagnosticoModule {}
