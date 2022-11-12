import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { EventosService } from '../services/eventos.service';
import { InicioService } from '../services/inicio.service';
import { EventoResponse } from '../interfaces/evento.response';
import { BannerResponse } from '../interfaces/banner.response';

@Injectable({
  providedIn: 'root',
})
export class InicioRepository {
  constructor(
    private inicioService: InicioService,
    private eventosService: EventosService
  ) {}

  listarBannerPrincipal = (): Observable<BannerResponse[]> => {
    return this.inicioService
      .listarBannerPrincipal()
      .pipe(map((response) => response.data as BannerResponse[]));
  };

  listarBannerPiePagina = (): Observable<BannerResponse[]> => {
    return this.inicioService
      .listarBannerPiePagina()
      .pipe(map((response) => response.data as BannerResponse[]));
  };

  listarEventos = (request: any): Observable<EventoResponse[]> => {
    return this.eventosService
      .listarEventos(request)
      .pipe(map((response) => response.data as EventoResponse[]));
  };
}
