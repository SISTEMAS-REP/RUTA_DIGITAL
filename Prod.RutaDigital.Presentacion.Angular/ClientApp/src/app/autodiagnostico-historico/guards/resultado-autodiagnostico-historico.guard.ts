import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
  UrlTree,
} from '@angular/router';
import { Observable, catchError } from 'rxjs';
import { map, tap, mergeMap } from 'rxjs/operators';
import { AutodiagnosticoHistoricoService } from '../autodiagnostico-historico.service';

@Injectable({
  providedIn: 'root',
})
export class ResultadoAutodiagnosticoHistoricoGuard implements CanActivate {
  constructor(
    private service: AutodiagnosticoHistoricoService,
    private router: Router
  ) {}
  canActivate(
    _next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | boolean
    | UrlTree
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree> {
    return this.service.verificarAutodiagnosticoHistorico().pipe(
      map((response) => {
        if (response.data?.concluido) {
          return true;
        }

        this.router.navigate(['/']);
        return false;
      }),
      catchError(() => this.router.navigate(['/']))
    );
  }
}
