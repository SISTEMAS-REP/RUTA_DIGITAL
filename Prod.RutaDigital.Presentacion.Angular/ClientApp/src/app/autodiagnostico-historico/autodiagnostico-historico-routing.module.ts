import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResultadoAutodiagnosticoHistoricoComponent } from './pages/resultado-autodiagnostico/resultado-autodiagnostico-historico.component';
import { ResultadoAutodiagnosticoHistoricoGuard } from './guards/resultado-autodiagnostico-historico.guard';

export const AutodiagnosticoHistoricoRoutes: Routes = [
  {
    path: 'resultado-hist',
    component: ResultadoAutodiagnosticoHistoricoComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(AutodiagnosticoHistoricoRoutes)],
  exports: [RouterModule],
})
export class AutodiagnosticoHistoricoRoutingModule {}
