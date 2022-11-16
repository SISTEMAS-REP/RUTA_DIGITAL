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
    path: 'auto-diagnostico',
    loadChildren: () =>
      import('./auto-diagnostico/auto-diagnostico.module').then(
        (m) => m.AutoDiagnosticoModule
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
      import('./perfil/perfil.module').then((m) => m.PerfilAvanceModule),
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
