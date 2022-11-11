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

  ListarEventos = (request: any): Observable<any> => {
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

  ListarPremio = (request: any): Observable<any> => {
    return this.bannerService
      .ListarPremio(request).pipe(
        map((response) => response.data));
  };

  ListarNivelPremio = (): Observable<any> => {
    return this.bannerService
      .ListarNivelPremio().pipe(
        map((response) => response.data));
  };

  ListarPuntajePremio = (): Observable<any> => {
    return this.bannerService
      .ListarPuntajePremio().pipe(
        map((response) => response.data));
  };

  RedireccionarLoginUnico = (request: any): Observable<any> => {
    return this.bannerService
      .RedireccionarLoginUnico(request).pipe(
        map((response) => response.data));
  };

  VerificarAutoDiagnosticoHistorico = (request: any): Observable<any> => {
    return this.bannerService
      .VerificarAutoDiagnosticoHistorico(request).pipe(
        map((response) => response.data));
  };

  VerificarAutoDiagnostico = (request: any): Observable<any> => {
    return this.bannerService
      .VerificarAutoDiagnostico(request).pipe(
        map((response) => response.data));
  };
}
