import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WeatherForecastComponent } from './pages/weather-forecast/weather-forecast.component';
import { CounterComponent } from './pages/counter/counter.component';
import { DemoComponent } from './demo.component';
import { AuthorizeGuard } from '../authorization/authorize.guard';

export const DemoRoutes: Routes = [
  {
    path: '',
    component: DemoComponent,
    children: [
      {
        path: 'counter',
        component: CounterComponent,
      },
      {
        path: 'weather-forecast',
        component: WeatherForecastComponent,
        canActivate: [AuthorizeGuard],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(DemoRoutes)],
  exports: [RouterModule],
})
export class DemoRoutingModule {}
