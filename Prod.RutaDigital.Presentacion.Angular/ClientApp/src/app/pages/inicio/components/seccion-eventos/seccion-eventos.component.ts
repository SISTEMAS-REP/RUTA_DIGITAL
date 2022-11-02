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
    mouseDrag: true,
    touchDrag: true,
    pullDrag: false,
    autoplay: true,
    dots: false,
    navSpeed: 700,
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
      980: {
        items: 4
      }
    }
  }
  

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
    this.router.navigate(['/eventos', id]);
  }
 

}
