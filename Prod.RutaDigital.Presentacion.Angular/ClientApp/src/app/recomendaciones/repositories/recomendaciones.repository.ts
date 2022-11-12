import { Injectable } from '@angular/core';
import { RecomendacionesService } from '../services/recomendaciones.service';

@Injectable({
  providedIn: 'root',
})
export class RecomendacionesRepository {
  constructor(private recomendacionesService: RecomendacionesService) {}
}
