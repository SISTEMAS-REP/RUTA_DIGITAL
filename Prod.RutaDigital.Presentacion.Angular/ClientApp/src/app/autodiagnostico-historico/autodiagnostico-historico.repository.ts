import { Injectable } from '@angular/core';
import { AutodiagnosticoHistoricoService } from './autodiagnostico-historico.service';
import { AuthorizeService } from '../authorization/authorize.service';
import { catchError, map, Observable, tap, throwError, concat, of } from 'rxjs';
import { ResultadoAutodiagnosticoHistorico } from './interfaces/resultado-autodiagnostico-historico';
import { ExtranetUser } from '../shared/interfaces/extranet-user';

@Injectable({
  providedIn: 'root',
})
export class AutodiagnosticoHistoricoRepository {
  constructor(
    private authorizeService: AuthorizeService,
    private autodiagnosticoHistoricoService: AutodiagnosticoHistoricoService
  ) {}

  obtenerUsuario = (): ExtranetUser => {
    const usuario = this.authorizeService.user;
    console.log('autodiagnostico-historico-repository/obtenerUsuario', usuario);
    return usuario;
  };

  verificarAutodiagnosticoHistorico = (): Observable<boolean> => {
    return this.autodiagnosticoHistoricoService.verificarAutodiagnosticoHistorico().pipe(
      tap((response) =>
        console.log(
          'autodiagnostico-historico-repository/VerificarAutodiagnosticoHistorico',
          response
        )
      ),
      map((response) => {
        var data = response.data;
        return data?.concluido ?? false;
      }),
      catchError(() => of(false))
    );
  };

  listarResultadoAutodiagnosticoHistorico = (): Observable<ResultadoAutodiagnosticoHistorico> => {
    return this.autodiagnosticoHistoricoService.listarResultadoAutodiagnosticoHistorico().pipe(
      tap((response) =>
        console.log(
          'autodiagnostico-historico-repository/listarResultadoAutodiagnosticoHistorico',
          response
        )
      ),
      map((response) => response.data as ResultadoAutodiagnosticoHistorico)
    );
  };
}
