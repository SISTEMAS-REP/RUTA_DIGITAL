import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { BannerService } from '../services/banner.service';

@Injectable({
  providedIn: 'root',
})
export class BannerRepository {
  constructor(private bannerService: BannerService) {}

  ListarBannerPrincipal = (): Observable<any> => {
    return this.bannerService
      .ListarBannerPrincipal().pipe(
        map((response) => response.data));
  };

  ListarBannerPiePagina = (): Observable<any> => {
    return this.bannerService
      .ListarBannerPiePagina()
      .pipe(map((response) => response.data));
  };

  ListarEventos = (request: any,): Observable<any> => {
    return this.bannerService
      .ListarEventos(request).pipe(
        map((response) => response.data));
  };

  ListarPublicidadPremio = (): Observable<any> => {
    return this.bannerService
      .ListarPublicidadPremio().pipe(
        map((response) => response.data));
  };

  ListarTipoPremio = (): Observable<any> => {
    return this.bannerService
      .ListarTipoPremio().pipe(
        map((response) => response.data));
  };

  ListarPremio = (): Observable<any> => {
    return this.bannerService
      .ListarPremio().pipe(
        map((response) => response.data));
  };
}
