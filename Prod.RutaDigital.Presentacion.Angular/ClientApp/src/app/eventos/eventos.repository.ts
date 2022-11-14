import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { EventosService } from './eventos.service';
import { EventoResponse } from './interfaces/evento.response';

@Injectable({
  providedIn: 'root',
})
export class EventosRepository {
  constructor(private eventosService: EventosService) {}

  listarEventos = (request: any): Observable<EventoResponse[]> => {
    return this.eventosService
      .listarEventos(request)
      .pipe(map((response) => response.data as EventoResponse[]));
  };
}
