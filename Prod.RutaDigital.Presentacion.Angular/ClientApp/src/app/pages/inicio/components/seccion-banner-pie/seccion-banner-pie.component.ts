import { Component, OnInit } from '@angular/core';
import { BannerRepository } from 'src/app/repositories/banner.repository';

@Component({
  selector: 'app-seccion-banner-pie',
  templateUrl: './seccion-banner-pie.component.html'
})
export class SeccionBannerPieComponent implements OnInit {
  listPiePagina : Array<any>;

  constructor(
    private bannerRepository: BannerRepository
  ) { }

  ngOnInit(): void {
    this.ListarBannerPiePagina();
  }

  ListarBannerPiePagina = () => {
    this.bannerRepository
    .ListarBannerPiePagina()
    .subscribe({
      next: (data : Array<any>) => {
        this.listPiePagina = data;

       
      },
      error: (err) => {
       
      },
    });
  };
}
