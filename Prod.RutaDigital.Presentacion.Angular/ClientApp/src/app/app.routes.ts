import { Routes } from '@angular/router';
import { CounterComponent } from './demo/counter/counter.component';
import { WeatherForecastComponent } from './demo/weather-forecast/weather-forecast.component';
import { InicioComponent } from './pages/inicio/inicio.component';
import { EventosComponent } from './pages/eventos/eventos.component';
import { AuthorizeGuard } from './authorization/authorize.guard';

export const routes: Routes = [
  {
    path: '',
    component: InicioComponent,
    pathMatch: 'full',
    data: { state: 'inicio' },
  },
  { path: 'eventos', component: EventosComponent },

  /*DEMO*/
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
