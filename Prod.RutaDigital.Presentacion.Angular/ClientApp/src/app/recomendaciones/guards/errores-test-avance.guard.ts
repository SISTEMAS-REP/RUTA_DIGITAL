import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
  UrlTree,
  ActivatedRoute,
} from '@angular/router';
import { Observable, catchError } from 'rxjs';
import { map, tap, mergeMap } from 'rxjs/operators';
import { RecomendacionRequest } from '../interfaces/request/recomendacion.request';
import { RecomendacionesService } from '../services/recomendaciones.service';
import { DateAdapter } from 'angular-calendar';

@Injectable({
  providedIn: 'root',
})
export class ErroresTestAvanceGuard implements CanActivate {
  constructor(
    private service: RecomendacionesService,
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
    const idRecomendacion = _next.params['idRecomendacion'];
    const request: RecomendacionRequest = {
      id_recomendacion: idRecomendacion,
    };

    return this.service.validarCapacitacionesErradas(request).pipe(
      map((response) => response.data as number),
      map((data) => {
        if (data < 3) {
          return true;
        }

        this.router.navigate(['/']);
        return false;
      }),
      catchError(() => this.router.navigate(['/']))
    );
  }
}
