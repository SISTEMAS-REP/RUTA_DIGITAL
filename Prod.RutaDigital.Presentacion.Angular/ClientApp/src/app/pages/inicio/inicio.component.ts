import { Component, OnInit } from '@angular/core';
import { BannerRepository } from 'src/app/repositories/banner.repository';
import { EventoRepository } from 'src/app/repositories/evento.repository';
import { InicioRepository } from '../../repositories/inicio.repository';
import { OwlOptions } from 'ngx-owl-carousel-o';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: [],
})
export class InicioComponent implements OnInit {
  
  listBanner : Array<any>;
  listPiePagina : Array<any>;
  title = 'ng-carousel-demo';
   
  customOptions: OwlOptions = {
    loop: true,
    mouseDrag: false,
    touchDrag: false,
    pullDrag: false,
    autoplay: true,
    dots: false,
    navSpeed: 700,
    navText: ['', ''],
    responsive: {
      0: {
        items: 1
      },
      400: {
        items: 2
      },
      740: {
        items: 3
      },
      940: {
        items: 4
      }
    },
    nav: true
  }
   
    slides = [
      {id: 1, img: "https://dummyimage.com/350x150/423b42/fff"},
      {id: 2, img: "https://dummyimage.com/350x150/2a2b7a/fff"},
      {id: 3, img: "https://dummyimage.com/350x150/1a2b7a/fff"},
      {id: 4, img: "https://dummyimage.com/350x150/7a2b7a/fff"},
      {id: 5, img: "https://dummyimage.com/350x150/9a2b7a/fff"},
      {id: 6, img: "https://dummyimage.com/350x150/5a2b7a/fff"},
      {id: 6, img: "https://dummyimage.com/350x150/4a2b7a/fff"}
    ];


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
