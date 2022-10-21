import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any>(baseUrl + 'weatherforecast').subscribe({
      next: (result) => {
        console.log('result', result);
        this.forecasts = result.data as WeatherForecast[];
      },
      error: (error) => {
        console.error('error', error);
      },
    });
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
