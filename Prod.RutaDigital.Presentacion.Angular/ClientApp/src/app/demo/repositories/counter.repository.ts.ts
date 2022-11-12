import { Injectable } from '@angular/core';
import { WeatherForecastService } from '../services/weather-forecast.service';
import { map, Observable } from 'rxjs';
import { WeatherForecast } from '../interfaces/weather-forecast';
import { catchError } from 'rxjs/operators';
import { AuthorizeService } from '../../authorization/authorize.service';
import { ExtranetUser } from '../../shared/interfaces/extranet-user';

@Injectable({
  providedIn: 'root',
})
export class CounterRepository {
  constructor(private authorizeService: AuthorizeService) {}

  getUser = (): Observable<ExtranetUser> => {
    return this.authorizeService
      .getUser()
      .pipe(map((response) => response as ExtranetUser));
  };
}
