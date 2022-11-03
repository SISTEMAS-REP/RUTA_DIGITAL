import { Component, OnInit } from '@angular/core';
import { BannerRepository } from 'src/app/repositories/banner.repository';
import { DomSanitizer } from '@angular/platform-browser';
import { BannerResponse } from 'src/app/interfaces/banner';

@Component({
  selector: 'app-seccion-banner-principal',
  templateUrl: './seccion-banner-principal.component.html'
})
export class SeccionBannerPrincipalComponent implements OnInit {
  listBanner : Array<any>;

  constructor(
    private bannerRepository: BannerRepository,
    private sanitizer: DomSanitizer
  ) { }

  ngOnInit(): void {
    this.ListarBannerPrincipal();
  }


  ListarBannerPrincipal = () => {
    this.bannerRepository
    .ListarBannerPrincipal()
    .subscribe({
      next: (data : Array<BannerResponse>) => {
        
        this.listBanner = data;
        this.listBanner.forEach(element => {
          let objectURL = 'data:image/png;base64,' + element.numArray;
          element.imagenEvento = this.sanitizer.bypassSecurityTrustUrl(objectURL);
        });
      },
      error: (err) => {
       
      },
    });
  };

}
