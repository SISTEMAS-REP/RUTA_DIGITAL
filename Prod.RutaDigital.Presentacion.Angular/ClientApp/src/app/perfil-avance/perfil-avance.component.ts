import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { CatalogoPremiosRepository } from '../catalogo-premios/catalogo-premios.repository';
import { PremioResponse } from '../catalogo-premios/interfaces/premio.response';

@Component({
  selector: 'app-perfil-avance',
  templateUrl: './perfil-avance.component.html',
  styleUrls: [],
})
export class PerfilAvanceComponent implements OnInit {
  nuevosPremios: PremioResponse[];
  constructor(
    private catalogoPremios: CatalogoPremiosRepository,
    private sanitizer: DomSanitizer,
    private router: Router
  ) {}

  ngOnInit(): void {}

  listarPremioNuevo = () => {
    var request: any = {
      CantReg: 10,
      IdListCatalogo: 1,
    };
    this.catalogoPremios.listarPremio(request).subscribe({
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

  loQuiero = (item) => {
    this.router.navigate(['/catalogo-premios/premio', item]);
  };
}
