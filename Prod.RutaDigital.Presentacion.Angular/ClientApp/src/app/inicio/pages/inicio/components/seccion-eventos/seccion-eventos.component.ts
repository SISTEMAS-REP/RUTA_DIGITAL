import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { EventoResponse } from 'src/app/inicio/interfaces/evento.response';
import { InicioRepository } from '../../../../repositories/inicio.repository';

@Component({
  selector: 'app-seccion-eventos',
  templateUrl: './seccion-eventos.component.html',
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
        items: 1,
      },
      400: {
        items: 2,
      },
      740: {
        items: 3,
      },
      980: {
        items: 4,
      },
    },
  };

  eventos: EventoResponse[];

  constructor(
    private repository: InicioRepository,
    private router: Router,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit(): void {
    this.listarEventos();
  }

  listarEventos = () => {
    var request: any = {
      id_evento: null,
      id_filtro: null,
    };

    this.repository.listarEventos(request).subscribe({
      next: (data: EventoResponse[]) => {
        this.eventos = data.map((evento) => {
          const objectURL = 'data:image/png;base64,' + evento.numArray;
          evento.imagenEvento =
            this.sanitizer.bypassSecurityTrustUrl(objectURL);

          return evento;
        });
      },
      error: (err) => {
        console.log('listarEventos', err);
      },
    });
  };

  verEvento = (id) => {
    this.router.navigate(['/eventos', id]);
  };
}
