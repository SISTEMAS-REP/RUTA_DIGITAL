import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ComunService } from '../services/comun.service';

@Injectable({
  providedIn: 'root',
})
export class ComunRepository {
  constructor(private eventoService: ComunService) {}

  RedireccionarLoginUnico = (request: any): Observable<any> => {
    return this.eventoService
      .RedireccionarLoginUnico(request).pipe(
        map((response) => response.data));
  };
}
