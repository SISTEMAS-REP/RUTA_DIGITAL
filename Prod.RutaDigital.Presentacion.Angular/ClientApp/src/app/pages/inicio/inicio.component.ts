import { Component, OnInit } from '@angular/core';
import { BannerRepository } from 'src/app/repositories/banner.repository';
import { WeatherForecastRepository } from 'src/app/repositories/weather-forecast.repository';
import { WeatherForecastService } from 'src/app/services/weather-forecast.service';
import { InicioRepository } from '../../repositories/inicio.repository';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: [],
})
export class InicioComponent implements OnInit {
  
  constructor(
    private repository: InicioRepository,
    private bannerRepository: BannerRepository,
    private weatherForecastRepository: WeatherForecastRepository) {}

  ngOnInit(): void {
    this.ListarBannerPrincipal();
  }

  ListarBannerPrincipal = () => {
    debugger
    this.weatherForecastRepository
    .listarWeatherForecast()
    .subscribe({
      next: (data) => {
       debugger
      },
      error: (err) => {
       
      },
    });
  };
}
