import { Component, Inject } from '@angular/core';
import { WeatherForecastRepository } from '../../repositories/weather-forecast.repository';
import { WeatherForecast } from '../../interfaces/weather-forecast';

@Component({
  selector: 'app-weather-forecast',
  templateUrl: './weather-forecast.component.html',
})
export class WeatherForecastComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(private repository: WeatherForecastRepository) {
    this.listarWeatherForecast();
  }

  listarWeatherForecast() {
    this.repository.listarWeatherForecast().subscribe({
      next: (data) => {
        this.forecasts = data;
      },
      error: (error) => {
        console.error('listarWeatherForecast', error);
      },
    });
  }
}
