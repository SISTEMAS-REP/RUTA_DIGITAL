import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { PremioPublicidadResponse } from './interfaces/premio-publicidad.response';
import { CatalogoPremiosRepository } from './catalogo-premios.repository';
import { AuthorizeService } from '../authorization/authorize.service';
import { Router } from '@angular/router';
import { ToastService } from '../shared/services/toast.service';

@Component({
  selector: 'app-catalogo-premios',
  templateUrl: './catalogo-premios.component.html',
  styleUrls: [],
})
export class CatalogoPremiosComponent implements OnInit {
  isAuthenticated: boolean = false;
  premiosPublicidad: PremioPublicidadResponse[];

  constructor(
    private repository: CatalogoPremiosRepository,
    private sanitizer: DomSanitizer,
    private router: Router,
    private authorizeService: AuthorizeService,
    private toastService: ToastService
  ) {
    this.authorizeService.isAuthenticated().subscribe((status) => {
      this.isAuthenticated = status;
    });
  }

  ngOnInit(): void {
    this.fnVerificacionCookies();
    this.listarPublicidadPremio();

  }

  
  fnVerificacionCookies= () =>{
    if(this.isAuthenticated){
        this.router.navigate(['/catalogo-premios/categoria-premios']);
    }
    else{
      this.toastService.danger("Debe iniciar sesión", "Error");
      this.router.navigate(['/']);
    }
  }

  listarPublicidadPremio = () => {
    this.repository.listarPublicidadPremio().subscribe({
      next: (data: PremioPublicidadResponse[]) => {
        this.premiosPublicidad = data.map((premioPublicidad) => {
          const objectURL =
            'data:image/png;base64,' + premioPublicidad.numArray;
          premioPublicidad.imagenPremioPublicidad =
            this.sanitizer.bypassSecurityTrustUrl(objectURL);

          return premioPublicidad;
        });
      },
      error: (err) => {},
    });
  };
}
