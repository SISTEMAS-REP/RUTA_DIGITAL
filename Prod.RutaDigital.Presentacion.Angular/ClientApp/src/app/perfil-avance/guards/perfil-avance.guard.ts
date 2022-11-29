import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  Router,
  UrlTree,
} from '@angular/router';
import { Observable, catchError } from 'rxjs';
import { map } from 'rxjs/operators';
import { AutodiagnosticoService } from 'src/app/autodiagnostico/autodiagnostico.service';

@Injectable({
  providedIn: 'root',
})
export class PerfilAvanceGuard implements CanActivate {
  constructor(
    private service: AutodiagnosticoService,
    private router: Router
  ) {}
  canActivate(
    _next: ActivatedRouteSnapshot
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
