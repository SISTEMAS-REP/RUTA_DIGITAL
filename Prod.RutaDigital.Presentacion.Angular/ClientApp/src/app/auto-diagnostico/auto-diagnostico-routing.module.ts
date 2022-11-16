import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AutoDiagnosticoComponent } from './auto-diagnostico.component';

export const AutoDiagnosticoRoutes: Routes = [
  {
    path: '',
    component: AutoDiagnosticoComponent,
  },
  { path: "test", component: AutoDiagnosticoComponent, loadChildren: () => import("./pages/test-autodiagnostico/test-autodiagnostico.module").then(m => m.TestAutoDiagnosticoModule) },  
  { path: "resultado-test", component: AutoDiagnosticoComponent, loadChildren: () => import("./pages/resultado-autodiagnostico/resultado-autodiagnostico.module").then(m => m.ResultadoAutoDiagnosticoModule) },
];

@NgModule({
  imports: [RouterModule.forChild(AutoDiagnosticoRoutes)],
  exports: [RouterModule],
})
export class AutoDiagnosticoRoutingModule {}
