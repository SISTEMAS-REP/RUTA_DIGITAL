import { Injectable } from '@angular/core';
import { WeatherForecastService } from '../services/weather-forecast.service';
import { map, Observable } from 'rxjs';
import { WeatherForecast } from '../interfaces/weather-forecast';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class WeatherForecastRepository {
  constructor(private weatherForecastService: WeatherForecastService) {}

  listarWeatherForecast = (): Observable<WeatherForecast[]> => {
    return this.weatherForecastService
      .GetWeatherForecasts()
      .pipe(map((response) => response.data as WeatherForecast[]));
  };
}
