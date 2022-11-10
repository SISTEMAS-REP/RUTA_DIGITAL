import { Routes } from '@angular/router';
import { CounterComponent } from './demo/counter/counter.component';
import { WeatherForecastComponent } from './demo/weather-forecast/weather-forecast.component';
import { InicioComponent } from './pages/inicio/inicio.component';
import { AuthorizeGuard } from './authorization/authorize.guard';

export const routes: Routes = [
  {
    path: '',
    component: InicioComponent,
    pathMatch: 'full',
    data: { state: 'inicio' },
  },
  { path: 'inicio', component: InicioComponent ,
    loadChildren: () => import('./pages/inicio/inicio.module').then((m) => m.InicioModule)
  },
  {
    path: 'eventos',
    loadChildren: () => import('./pages/eventos/eventos.module').then((m) => m.EventosModule)
  },
  {
    path: 'eventos/:id',
    loadChildren: () => import('./pages/eventos/eventos.module').then((m) => m.EventosModule)
  },
  {
    path: 'premios',
    loadChildren: () => import('./pages/premios/premios.module').then((m) => m.PremiosModule)
  },

  /*AVANCE DE VERONICA*/
  {
    path: 'veronica',
    loadChildren: () => import('./pages/veronica/veronica.module').then((m) => m.VeronicaModule)
  },
  
    /*****************/

  {
    path: 'counter',
    component: CounterComponent,
    canActivate: [AuthorizeGuard],
  },
  {
    path: 'weather-forecast',
    component: WeatherForecastComponent,
  },
];
