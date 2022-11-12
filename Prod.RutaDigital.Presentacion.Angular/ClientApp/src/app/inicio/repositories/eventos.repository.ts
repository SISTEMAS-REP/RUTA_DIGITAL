import { Injectable } from '@angular/core';
import { EventosService } from '../services/eventos.service';

@Injectable({
  providedIn: 'root',
})
export class EventosRepository {
  constructor(private eventosService: EventosService) {}
}
