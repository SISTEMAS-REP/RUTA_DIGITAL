import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestAutodiagnosticoComponent } from './test-autodiagnostico.component';

export const TestAutoDiagnosticoRoutes: Routes = [
  {
    path: '',
    component: TestAutodiagnosticoComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(TestAutoDiagnosticoRoutes)],
  exports: [RouterModule],
})
export class TestAutoDiagnosticoRoutingModule {}
