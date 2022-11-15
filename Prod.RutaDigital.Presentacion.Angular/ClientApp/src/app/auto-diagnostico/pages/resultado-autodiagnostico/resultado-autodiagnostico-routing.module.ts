import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResultadoAutodiagnosticoComponent } from './resultado-autodiagnostico.component';

export const ResultadoAutoDiagnosticoRoutes: Routes = [
  {
    path: '',
    component: ResultadoAutodiagnosticoComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(ResultadoAutoDiagnosticoRoutes)],
  exports: [RouterModule],
})
export class ResultadoAutoDiagnosticoRoutingModule {}
