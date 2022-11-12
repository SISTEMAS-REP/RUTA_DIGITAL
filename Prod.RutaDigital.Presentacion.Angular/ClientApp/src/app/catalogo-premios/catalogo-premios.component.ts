import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { PremioPublicidadResponse } from './interfaces/premio-publicidad.response';
import { CatalogoPremiosRepository } from './catalogo-premios.repository';

@Component({
  selector: 'app-catalogo-premios',
  templateUrl: './catalogo-premios.component.html',
  styleUrls: [],
})
export class CatalogoPremiosComponent implements OnInit {
  premiosPublicidad: PremioPublicidadResponse[];

  constructor(
    private repository: CatalogoPremiosRepository,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit(): void {
    this.listarPublicidadPremio();
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
