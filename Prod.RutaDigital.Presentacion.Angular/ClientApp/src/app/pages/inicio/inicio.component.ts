import { Component, OnInit } from '@angular/core';
import { BannerRepository } from 'src/app/repositories/banner.repository';
import { EventoRepository } from 'src/app/repositories/evento.repository';
import { InicioRepository } from '../../repositories/inicio.repository';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: [],
})
export class InicioComponent implements OnInit {
  
  listBanner : Array<any>;
  listPiePagina : Array<any>;
  listEvento: Array<any>;

  constructor(
    private bannerRepository: BannerRepository,
    private eventoRepository: EventoRepository) {}

  ngOnInit(): void {
    this.ListarBannerPrincipal();
    this.ListarBannerPiePagina();
    this.ListarEvento();
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
        this.listPiePagina = data;

       
      },
      error: (err) => {
       
      },
    });
  };

  ListarEvento = () => {
    this.eventoRepository
    .ListarEventos()
    .subscribe({
      next: (data : Array<any>) => {
        debugger
        this.listEvento = data;
      },
      error: (err) => {
       
      },
    });
  };


}
