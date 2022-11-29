import { Injectable } from '@angular/core';
import { AutodiagnosticoService } from './autodiagnostico.service';
import { AuthorizeService } from '../authorization/authorize.service';
import { TestAutodiagnostico } from './interfaces/test-autodiagnostico';
import { catchError, map, Observable, tap, throwError, concat, of } from 'rxjs';
import { RespuestaRequest } from './interfaces/request/respuesta.request';
import { Respuesta } from './interfaces/respuesta';
import { ModuloRequest } from './interfaces/request/modulo.request';
import { ResultadoAutodiagnostico } from './interfaces/resultado-autodiagnostico';
import { ExtranetUser } from '../shared/interfaces/extranet-user';

@Injectable({
  providedIn: 'root',
})
export class AutodiagnosticoRepository {
  constructor(
    private authorizeService: AuthorizeService,
    private autodiagnosticoService: AutodiagnosticoService
  ) {}

  obtenerUsuario = (): ExtranetUser => {
    const usuario = this.authorizeService.user;
    console.log('autodiagnostico-repository/obtenerUsuario', usuario);
    return usuario;
  };

  verificarAutodiagnostico = (): Observable<boolean> => {
    return this.autodiagnosticoService.verificarAutodiagnostico().pipe(
      tap((response) =>
        console.log(
          'autodiagnostico-repository/verificarAutodiagnostico',
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

  listarTestAutodiagnostico = (): Observable<TestAutodiagnostico> => {
    return this.autodiagnosticoService.listarTestAutodiagnostico().pipe(
      tap((response) =>
        console.log(
          'autodiagnostico-repository/listarPublicidadPremio',
          response
        )
      ),
      map((response) => response.data as TestAutodiagnostico)
    );
  };

  actualizarRespuesta(request: RespuestaRequest): Observable<Respuesta[]> {
    return this.autodiagnosticoService
      .actualizarRespuesta(request)
      .pipe(map((response) => response.data as Respuesta[]));
  }

  validarModulo(request: ModuloRequest): Observable<boolean> {
    return this.autodiagnosticoService
      .validarModulo(request)
      .pipe(map((response) => response.data as boolean));
  }

  procesarEvaluacion(): Observable<boolean> {
    return this.autodiagnosticoService
      .procesarEvaluacion()
      .pipe(map((response) => response.data as boolean));
  }

  listarResultadoAutodiagnostico = (): Observable<ResultadoAutodiagnostico> => {
    return this.autodiagnosticoService.listarResultadoAutodiagnostico().pipe(
      tap((response) =>
        console.log(
          'autodiagnostico-repository/listarResultadoAutodiagnostico',
          response
        )
      ),
      map((response) => response.data as ResultadoAutodiagnostico)
    );
  };

  VerificarAutodiagnosticoHistorico = (): Observable<boolean> => {
    return this.autodiagnosticoService.VerificarAutodiagnosticoHistorico().pipe(
      tap((response) =>
        console.log(
          'autodiagnostico-repository/VerificarAutodiagnosticoHistorico',
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
}
