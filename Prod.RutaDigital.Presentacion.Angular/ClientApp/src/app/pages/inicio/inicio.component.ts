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

  constructor(
    private bannerRepository: BannerRepository) {}

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
