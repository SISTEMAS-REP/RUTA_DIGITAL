import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { BannerResponse } from 'src/app/inicio/interfaces/banner.response';
import { InicioRepository } from 'src/app/inicio/inicio.repository';

@Component({
  selector: 'app-seccion-banner-principal',
  templateUrl: './seccion-banner-principal.component.html',
})
export class SeccionBannerPrincipalComponent implements OnInit {
  banners: BannerResponse[];

  constructor(
    private repository: InicioRepository,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit(): void {
    this.listarBannerPrincipal();
  }

  listarBannerPrincipal = () => {
    this.repository.listarBannerPrincipal().subscribe({
      next: (data: BannerResponse[]) => {
        this.banners = data.map((banner) => {
          const objectURL = 'data:image/png;base64,' + banner.numArray;
          banner.imagenBanner =
            this.sanitizer.bypassSecurityTrustUrl(objectURL);

          return banner;
        });
      },
      error: (err) => {
        console.log('listarBannerPrincipal', err);
      },
    });
  };
}
