import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { BannerRepository } from 'src/app/repositories/banner.repository';


@Component({
  selector: 'app-seccion-eventos',
  templateUrl: './seccion-eventos.component.html'
})
export class SeccionEventosComponent implements OnInit {
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
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.ListarEvento();
  }

  ListarEvento = () => {
    var request: any = {
      id_evento: null,
      id_filtro: null
    };

    this.bannerRepository
    .ListarEventos(request)
    .subscribe({
      next: (data : Array<any>) => {
        this.listEvento = data;
      },
      error: (err) => {
       
      },
    });
  };

  verEvento = (id) =>{
    debugger
    this.router.navigate(['/eventos', id]);
  }
 

}
