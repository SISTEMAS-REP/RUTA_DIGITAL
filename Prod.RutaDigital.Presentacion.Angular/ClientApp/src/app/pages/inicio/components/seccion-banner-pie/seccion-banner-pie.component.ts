import { Component, OnInit } from '@angular/core';
import { BannerRepository } from 'src/app/repositories/banner.repository';
import { DomSanitizer } from '@angular/platform-browser';
import { BannerResponse } from 'src/app/interfaces/banner';

@Component({
  selector: 'app-seccion-banner-pie',
  templateUrl: './seccion-banner-pie.component.html'
})
export class SeccionBannerPieComponent implements OnInit {
  listPiePagina : Array<any>;

  constructor(
    private bannerRepository: BannerRepository,
    private sanitizer: DomSanitizer
  ) { }

  ngOnInit(): void {
    this.ListarBannerPiePagina();
  }


  ListarBannerPiePagina = () => {
    this.bannerRepository
    .ListarBannerPiePagina()
    .subscribe({
      next: (data : Array<BannerResponse>) => {
        
        this.listPiePagina = data;
        this.listPiePagina.forEach(element => {
          let objectURL = 'data:image/png;base64,' + element.numArray;
          element.imagenEvento = this.sanitizer.bypassSecurityTrustUrl(objectURL);
        });
      },
      error: (err) => {
       
      },
    });
  };
}
