import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AutodiagnosticoComponent } from './components/autodiagnostico/autodiagnostico.component';
import { DetalleRecomendacionesComponent } from './components/detalle-recomendaciones/detalle-recomendaciones.component';
import { ModalsComponent } from './components/modals/modals.component';
import { RecomendacionesComponent } from './components/recomendaciones/recomendaciones.component';
import { TestAutodiagnosticoComponent } from './components/test-autodiagnostico/test-autodiagnostico.component';
import { TestAvanceComponent } from './components/test-avance/test-avance.component';
import { VeronicaComponent } from './veronica.component';



export const VeronicaRoutes: Routes = [
  {
    path: '',
    component: VeronicaComponent,
    children: [
      { path: '', redirectTo: '', pathMatch: 'full' },
      { path: "recomendaciones", component: RecomendacionesComponent, loadChildren: () => import("./components/recomendaciones/recomendaciones.module").then(m => m.RecomendacionesModule) },
      { path: "detalle-recomendaciones", component: DetalleRecomendacionesComponent, loadChildren: () => import("./components/detalle-recomendaciones/detalle-recomendaciones.module").then(m => m.DetalleRecomendacionesModule) },
      { path: "autodiagnostico", component: AutodiagnosticoComponent, loadChildren: () => import("./components/autodiagnostico/autodiagnostico.module").then(m => m.AutodiagnosticoModule) },
      { path: "test-autodiagnostico", component: TestAutodiagnosticoComponent, loadChildren: () => import("./components/test-autodiagnostico/test-autodiagnostico.module").then(m => m.TestAutodiagnosticoModule) },
      { path: "test-avance", component: TestAvanceComponent, loadChildren: () => import("./components/test-avance/test-avance.module").then(m => m.TestAvanceModule) },
      { path: "modals", component: ModalsComponent, loadChildren: () => import("./components/modals/modals.module").then(m => m.ModalsModule) },

    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(VeronicaRoutes)],
  exports: [RouterModule],
})
export class VeronicaRoutingModule {}
