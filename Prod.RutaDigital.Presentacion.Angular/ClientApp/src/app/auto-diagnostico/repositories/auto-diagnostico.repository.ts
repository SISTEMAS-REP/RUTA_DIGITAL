import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { AutodiagnosticoService } from '../services/auto-diagnostico.service';
import { AuthorizeService } from '../../authorization/authorize.service';
import { ExtranetUser } from '../../shared/interfaces/extranet-user';

@Injectable({
  providedIn: 'root',
})
export class AutodiagnosticoRepository {
  constructor(private autodiagnosticoService: AutodiagnosticoService,
  private authorizeService: AuthorizeService
  ) {

  }
  
  getUser = (): Observable<ExtranetUser> => {
    return this.authorizeService
      .getUser()
      .pipe(map((response) => response as ExtranetUser));
  };

  VerificarAutoDiagnosticoHistorico = (request: any): Observable<any> => {
    return this.autodiagnosticoService
      .VerificarAutoDiagnosticoHistorico(request).pipe(
        map((response) => response.data));
  };

  VerificarAutoDiagnostico = (request: any): Observable<any> => {
    return this.autodiagnosticoService
      .VerificarAutoDiagnostico(request).pipe(
        map((response) => response.data));
  };
}
