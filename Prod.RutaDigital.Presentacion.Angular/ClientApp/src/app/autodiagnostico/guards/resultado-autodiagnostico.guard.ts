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
import { AutodiagnosticoService } from '../autodiagnostico.service';
import { Evaluacion } from '../interfaces/evaluacion';

@Injectable({
  providedIn: 'root',
})
export class ResultadoAutodiagnosticoGuard implements CanActivate {
  constructor(
    private service: AutodiagnosticoService,
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
    return this.service.verificarAutodiagnostico().pipe(
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
