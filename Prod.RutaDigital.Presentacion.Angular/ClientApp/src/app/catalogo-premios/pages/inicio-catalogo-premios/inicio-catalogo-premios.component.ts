import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { CatalogoPremiosRepository } from '../../catalogo-premios.repository';
import { PremioTipoResponse } from '../../interfaces/premio-tipo.response';
import { PremioResponse } from '../../interfaces/premio.response';

@Component({
  selector: 'app-inicio-catalogo-premios',
  templateUrl: './inicio-catalogo-premios.component.html',
  styleUrls: [],
})
export class InicioCatalogoPremiosComponent implements OnInit {
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
        items: 1,
      },
      400: {
        items: 2,
      },
      740: {
        items: 3,
      },
      940: {
        items: 4,
      },
    },
  };

  tiposPremio: PremioTipoResponse[];
  nuevosPremios: PremioResponse[];
  nivelesPremios: PremioResponse[];

  constructor(
    private repository: CatalogoPremiosRepository,
    private sanitizer: DomSanitizer,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.listarTipoPremio();
    this.listarPremioNuevo();
    this.listarPremioNivel();
  }

  listarTipoPremio = () => {
    this.repository.listarTipoPremio().subscribe({
      next: (data: PremioTipoResponse[]) => {
        this.tiposPremio = data.map((tipoPremio) => {
          const objectURL = 'data:image/png;base64,' + tipoPremio.numArray;
          tipoPremio.imagenTipoPremio =
            this.sanitizer.bypassSecurityTrustUrl(objectURL);

          return tipoPremio;
        });
      },
      error: (err) => {},
    });
  };

  listarPremioNuevo = () => {
    var request: any = {
      CantReg: 10,
      IdListCatalogo: 1,
    };
    this.repository.listarPremio(request).subscribe({
      next: (data: PremioResponse[]) => {
        this.nuevosPremios = data.map((nuevoPremio) => {
          const objectURL = 'data:image/png;base64,' + nuevoPremio.numArray;
          nuevoPremio.imagenPremio =
            this.sanitizer.bypassSecurityTrustUrl(objectURL);

          let objectURLTipo =
            'data:image/png;base64,' + nuevoPremio.fotoTipoArray;
          nuevoPremio.imagenTipoPremio =
            this.sanitizer.bypassSecurityTrustUrl(objectURLTipo);
          return nuevoPremio;
        });
      },
      error: (err) => {},
    });
  };

  listarPremioNivel = () => {
    var request: any = {
      CantReg: 10,
      IdListCatalogo: 2,
    };
    this.repository.listarPremio(request).subscribe({
      next: (data: PremioResponse[]) => {
        this.nivelesPremios = data.map((nivelPremio) => {
          const objectURL = 'data:image/png;base64,' + nivelPremio.numArray;
          nivelPremio.imagenPremio =
            this.sanitizer.bypassSecurityTrustUrl(objectURL);

          let objectURLTipo =
            'data:image/png;base64,' + nivelPremio.fotoTipoArray;
          nivelPremio.imagenTipoPremio =
            this.sanitizer.bypassSecurityTrustUrl(objectURLTipo);
          return nivelPremio;
        });
      },
      error: (err) => {},
    });
  };

  loQuiero = (item) => {
    this.router.navigate(['/catalogo-premios/premio', item]);
  };
  verMas = (item) => {
    this.router.navigate(['/catalogo-premios/categoria', item]);
  };

  fnVerTipoPremio = (item) => {
    this.router.navigate(['/catalogo-premios/categoria', 'tipo-' + item]);
  };
}
