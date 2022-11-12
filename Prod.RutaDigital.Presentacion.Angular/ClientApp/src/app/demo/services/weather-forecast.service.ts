import { Injectable } from '@angular/core';
import { BaseService } from '../../shared/services/base.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class WeatherForecastService extends BaseService {
  getControllerUrl(): string {
    return 'weatherforecast';
  }

  GetWeatherForecasts = (): Observable<any> => {
    return this.get('GetWeatherForecasts');
  };
}
