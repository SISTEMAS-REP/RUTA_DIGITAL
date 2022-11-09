import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { PremioService } from '../services/premio.service';

@Injectable({
  providedIn: 'root',
})
export class PremioRepository {
  constructor(private premioService: PremioService) {}

  ListarPublicidadPremio = (): Observable<any> => {
    return this.premioService
      .ListarPublicidadPremio().pipe(
        map((response) => response.data));
  };

  ListarTipoPremio = (): Observable<any> => {
    return this.premioService
      .ListarTipoPremio().pipe(
        map((response) => response.data));
  };

  ListarPremio = (): Observable<any> => {
    return this.premioService
      .ListarPremio().pipe(
        map((response) => response.data));
  };

  ListarNivelPremio = (): Observable<any> => {
    return this.premioService
      .ListarNivelPremio().pipe(
        map((response) => response.data));
  };

  ListarPuntajePremio = (): Observable<any> => {
    return this.premioService
      .ListarPuntajePremio().pipe(
        map((response) => response.data));
  };
}
