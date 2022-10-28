import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { EventoService } from '../services/evento.service';

@Injectable({
  providedIn: 'root',
})
export class EventoRepository {
  constructor(private eventoService: EventoService) {}

  ListarEventos = (): Observable<any> => {
    return this.eventoService
      .ListarEventos().pipe(
        map((response) => response.data));
  };
}
