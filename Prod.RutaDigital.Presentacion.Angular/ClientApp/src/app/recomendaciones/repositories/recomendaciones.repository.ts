import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { RecomendacionesService } from '../services/recomendaciones.service';
import { CapacitacionResultadoRequest } from '../interfaces/request/capacitacion-resultado.request';
import { Recomendacion } from '../interfaces/recomendacion';
import { Modulo } from '../../autodiagnostico/interfaces/modulo';
@Injectable({
  providedIn: 'root',
})
export class RecomendacionesRepository {
  constructor(private recomendacionesService: RecomendacionesService) {}

  listarCapacitaciones = (): Observable<Modulo[]> => {
    return this.recomendacionesService
      .listarCapacitaciones()
      .pipe(map((response) => response.data as Modulo[]));
  };

  listarRecomendacion = (
    request: CapacitacionResultadoRequest
  ): Observable<Recomendacion> => {
    return this.recomendacionesService
      .listarRecomendacion(request)
      .pipe(map((response) => response.data as Recomendacion));
  };
}
