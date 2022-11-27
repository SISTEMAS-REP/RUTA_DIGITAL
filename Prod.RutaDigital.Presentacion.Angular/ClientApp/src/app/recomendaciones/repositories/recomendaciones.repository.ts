import { Injectable } from '@angular/core';
import { map, Observable, tap } from 'rxjs';
import { RecomendacionesService } from '../services/recomendaciones.service';
import { CapacitacionResultadoRequest } from '../interfaces/request/capacitacion-resultado.request';
import { Recomendacion } from '../interfaces/recomendacion';
import { TestAvance } from 'src/app/recomendaciones/interfaces/test-avance';
import { RecomendacionRequest } from '../interfaces/request/recomendacion.request';
import { Modulo } from 'src/app/autodiagnostico/interfaces/modulo';
import { TestAvanceRequest } from '../interfaces/request/test-avance.request';

@Injectable({
  providedIn: 'root',
})
export class RecomendacionesRepository {
  constructor(private recomendacionesService: RecomendacionesService) { }

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

  listarTestAvance = (
    request: RecomendacionRequest
  ): Observable<TestAvance> => {
    return this.recomendacionesService
      .listarTestAvance(request)
      .pipe(tap((response) => console.log('RecomendacionesRepository/listarTestAvance', response)),
        map((response) => response.data as TestAvance));
  };

  procesarAvance(request: TestAvanceRequest): Observable<number> {
    return this.recomendacionesService
      .procesarAvance(request)
      .pipe(tap((response) => console.log('RecomendacionesRepository/procesarAvance', response)),
      map((response) => response.data as number));
  }
}
