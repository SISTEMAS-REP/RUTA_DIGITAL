import { Component, OnInit } from '@angular/core';
import { BannerRepository } from 'src/app/repositories/banner.repository';

@Component({
  selector: 'app-seccion-banner-principal',
  templateUrl: './seccion-banner-principal.component.html'
})
export class SeccionBannerPrincipalComponent implements OnInit {
  listBanner : Array<any>;

  constructor(
    private bannerRepository: BannerRepository,
  ) { }

  ngOnInit(): void {
    this.ListarBannerPrincipal();
  }


  ListarBannerPrincipal = () => {
    this.bannerRepository
    .ListarBannerPrincipal()
    .subscribe({
      next: (data : Array<any>) => {

        this.listBanner = data;

       
      },
      error: (err) => {
       
      },
    });
  };

}
