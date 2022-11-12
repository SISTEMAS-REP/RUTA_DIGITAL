import { Injectable } from '@angular/core';
import { DetalleRecomendacionService } from '../services/detalle-recomendacion.service';

@Injectable({
  providedIn: 'root',
})
export class DetalleRecomendacionRepository {
  constructor(
    private detalleRecomendacionService: DetalleRecomendacionService
  ) {}
}
