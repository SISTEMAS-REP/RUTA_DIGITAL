import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { InicioRepository } from '../../inicio.repository';
import { BannerResponse } from 'src/app/inicio/interfaces/banner.response';

@Component({
  selector: 'app-seccion-banner-pie',
  templateUrl: './seccion-banner-pie.component.html',
})
export class SeccionBannerPieComponent implements OnInit {
  banners: BannerResponse[];

  constructor(
    private repository: InicioRepository,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit(): void {
    this.listarBannerPiePagina();
  }

  listarBannerPiePagina = () => {
    this.repository.listarBannerPiePagina().subscribe({
      next: (data: BannerResponse[]) => {
        this.banners = data.map((banner) => {
          const objectURL = 'data:image/png;base64,' + banner.numArray;
          banner.imagenBanner =
            this.sanitizer.bypassSecurityTrustUrl(objectURL);

          return banner;
        });
      },
      error: (err) => {
        console.log('listarBannerPiePagina', err);
      },
    });
  };
}
