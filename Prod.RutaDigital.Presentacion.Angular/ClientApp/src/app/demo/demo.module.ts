import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DemoComponent } from './demo.component';
import { RouterModule } from '@angular/router';
import { CounterComponent } from './pages/counter/counter.component';
import { WeatherForecastComponent } from './pages/weather-forecast/weather-forecast.component';
import { DemoRoutingModule } from './demo-routing.module';

@NgModule({
  declarations: [DemoComponent, CounterComponent, WeatherForecastComponent],
  imports: [CommonModule, RouterModule, DemoRoutingModule],
})
export class DemoModule {}
