import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { PremioPublicidadResponse, PremioResponse, PremioTipoResponse } from 'src/app/interfaces/premio';
import { BannerRepository } from 'src/app/repositories/banner.repository';

@Component({
  selector: 'app-premios-catalogo',
  templateUrl: './premios-catalogo.component.html'
})
export class PremiosCatalogoComponent implements OnInit {
  customOptions: OwlOptions = {
    loop: true,
    mouseDrag: true,
    touchDrag: true,
    pullDrag: false,
    autoplay: true,
    dots: false,
    navSpeed: 700,
    navText: ['', ''],
    responsive: {
      0: {
        items: 1
      },
      400: {
        items: 2
      },
      740: {
        items: 3
      },
      940: {
        items: 4
      }
    }
  }
  listBanner : Array<any>;
  listTipoPremio : Array<any>;
  listNuevoPremio : Array<any>;
  listNivelPremio : Array<any>;
  constructor(
    private premioRepository: BannerRepository,
    private sanitizer: DomSanitizer,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.ListarPublicidadPremio();
    this.ListarTipoPremio();
    this.ListarPremioNuevo();
    this.ListarPremioNivel();
  }

  ListarPublicidadPremio = () => {
    this.premioRepository
    .ListarPublicidadPremio()
    .subscribe({
      next: (data : Array<PremioPublicidadResponse>) => {
        
        this.listBanner = data;
        this.listBanner.forEach(element => {
          let objectURL = 'data:image/png;base64,' + element.numArray;
          element.imagenPremioPublicidad = this.sanitizer.bypassSecurityTrustUrl(objectURL);
        });
      },
      error: (err) => {
       
      },
    });
  };

  

  ListarTipoPremio = () => {
    this.premioRepository
    .ListarTipoPremio()
    .subscribe({
      next: (data : Array<PremioTipoResponse>) => {
        
        this.listTipoPremio = data;
        this.listTipoPremio.forEach(element => {
          let objectURL = 'data:image/png;base64,' + element.numArray;
          element.imagenTipoPremio = this.sanitizer.bypassSecurityTrustUrl(objectURL);
        });
      },
      error: (err) => {
       
      },
    });
  };

  ListarPremioNuevo = () => {
    var request: any = {
      CantReg: 10,
      IdListCatalogo: 1
    };
    this.premioRepository
    .ListarPremio(request)
    .subscribe({
      next: (data : Array<PremioResponse>) => {
        
        this.listNuevoPremio = data;
        this.listNuevoPremio.forEach(element => {
          let objectURL = 'data:image/png;base64,' + element.numArray;
          element.imagenPremio = this.sanitizer.bypassSecurityTrustUrl(objectURL);
        });
      },
      error: (err) => {
       
      },
    });
  };

  ListarPremioNivel = () => {
    var request: any = {
      CantReg: 10,
      IdListCatalogo: 2
    };
    this.premioRepository
    .ListarPremio(request)
    .subscribe({
      next: (data : Array<PremioResponse>) => {
        
        this.listNivelPremio = data;
        this.listNivelPremio.forEach(element => {
          let objectURL = 'data:image/png;base64,' + element.numArray;
          element.imagenPremio = this.sanitizer.bypassSecurityTrustUrl(objectURL);
        });
      },
      error: (err) => {
       
      },
    });
  };

  loQuiero = (item) =>
  {
    this.router.navigate(['/premios/premios-detalle', item]);
  }
  verMas = (item) =>
  {
    this.router.navigate(['/premios/premios-listado', item]);
  }

  fnVerTipoPremio = (item) =>
  {
    this.router.navigate(['/premios/premios-listado', "tipo-" + item]);
  }
}
