import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

export const AppRoutes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./inicio/inicio.module').then((m) => m.InicioModule),
  },
  {
    path: 'eventos',
    loadChildren: () =>
      import('./eventos/eventos.module').then((m) => m.EventosModule),
  },
  {
    path: 'autodiagnostico',
    loadChildren: () =>
      import('./autodiagnostico/autodiagnostico.module').then(
        (m) => m.AutodiagnosticoModule
      ),
  },
  {
    path: 'autodiagnostico-historico',
    loadChildren: () =>
      import('./autodiagnostico-historico/autodiagnostico-historico.module').then(
        (m) => m.AutodiagnosticoHistoricoModule
      ),
  },
  {
    path: 'recomendaciones',
    loadChildren: () =>
      import('./recomendaciones/recomendaciones.module').then(
        (m) => m.RecomendacionesModule
      ),
  },
  {
    path: 'perfil-avance',
    loadChildren: () =>
      import('./perfil-avance/perfil-avance.module').then(
        (m) => m.PerfilAvanceModule
      ),
  },
  {
    path: 'catalogo-premios',
    loadChildren: () =>
      import('./catalogo-premios/catalogo-premios.module').then(
        (m) => m.CatalogoPremiosModule
      ),
  },
  {
    path: 'demo',
    loadChildren: () => import('./demo/demo.module').then((m) => m.DemoModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(AppRoutes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
