import { Component, OnInit } from '@angular/core';
import { BannerRepository } from 'src/app/repositories/banner.repository';
import { InicioRepository } from '../../repositories/inicio.repository';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: [],
})
export class InicioComponent implements OnInit {
  
  listBanner : Array<any>;
  listPiePagina : Array<any>;

  constructor(
    private bannerRepository: BannerRepository) {}

  ngOnInit(): void {
    this.ListarBannerPrincipal();
    this.ListarBannerPiePagina();
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

  ListarBannerPiePagina = () => {
    this.bannerRepository
    .ListarBannerPiePagina()
    .subscribe({
      next: (data : Array<any>) => {
        debugger
        this.listPiePagina = data;

       
      },
      error: (err) => {
       
      },
    });
  };
}
