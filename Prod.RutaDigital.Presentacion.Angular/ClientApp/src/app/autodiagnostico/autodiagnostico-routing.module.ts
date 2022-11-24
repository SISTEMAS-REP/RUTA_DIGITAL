import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResultadoAutodiagnosticoComponent } from './pages/resultado-autodiagnostico/resultado-autodiagnostico.component';
import { TestAutodiagnosticoComponent } from './pages/test-autodiagnostico/test-autodiagnostico.component';
import { TestAutodiagnosticoGuard } from './guards/test-autodiagnostico.guard';
import { ResultadoAutodiagnosticoGuard } from './guards/resultado-autodiagnostico.guard';

export const AutodiagnosticoRoutes: Routes = [
  {
    path: 'resultado',
    component: ResultadoAutodiagnosticoComponent,
    canActivate: [ResultadoAutodiagnosticoGuard],
  },
  {
    path: 'test',
    component: TestAutodiagnosticoComponent,
    canActivate: [TestAutodiagnosticoGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(AutodiagnosticoRoutes)],
  exports: [RouterModule],
})
export class AutodiagnosticoRoutingModule {}
