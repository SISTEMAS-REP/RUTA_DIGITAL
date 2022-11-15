import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AutodiagnosticoComponent } from './autodiagnostico.component';
import { TestAutodiagnosticoComponent } from './pages/test-autodiagnostico/test-autodiagnostico.component';

export const AutodiagnosticoRoutes: Routes = [
  {
    path: '',
    component: AutodiagnosticoComponent,
  },
  {
    path: 'test',
    component: TestAutodiagnosticoComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(AutodiagnosticoRoutes)],
  exports: [RouterModule],
})
export class AutodiagnosticoRoutingModule {}
