import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { EventoResponse } from 'src/app/eventos/interfaces/evento.response';
import { EventosRepository } from '../../eventos.repository';

@Component({
  selector: 'app-eventos-seleccion',
  templateUrl: './eventos-seleccion.component.html',
})
export class EventosSeleccionComponent implements OnInit {
  eventos: EventoResponse[];
  evento: EventoResponse;
  id_filtro: number = null;
  id_evento: number = null;
  latitud: number = 0;
  longitud: number = 0;
  is_ver_mapa: Boolean = false;
  center: google.maps.LatLngLiteral = {
    lat: 0,
    lng: 0,
  };

  zoom = 16;

  markerOptions: google.maps.MarkerOptions = {
    draggable: true,
  };

  markerPositions: google.maps.LatLngLiteral[] = [];

  is_verdetalle: boolean = true;
  constructor(
    private repository: EventosRepository,
    private router: ActivatedRoute,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit(): void {
    this.router.params.subscribe((params) => {
      const id_evento = params['evento'];
      this.id_evento = id_evento;
      this.verEvento();
    });

    this.listarEventos();
    this.verEvento();
  }

  filter = (evento) => {
    this.is_verdetalle = false;
    this.id_filtro = evento;
    this.listarEventos();
  };

  seleccionarEvento = (evento) => {
    this.id_evento = evento;
    this.verEvento();
  };

  listarEventos = () => {
    var request: any = {
      id_evento: null,
      id_filtro: this.id_filtro,
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

  verEvento = () => {
    this.is_ver_mapa = false;
    var request: any = {
      id_evento: this.id_evento,
      id_filtro: null,
    };

    this.repository.listarEventos(request).subscribe({
      next: (data: Array<EventoResponse>) => {
        this.is_verdetalle = true;
        this.is_ver_mapa = true;

        this.evento = data[0];
        let objectURL = 'data:image/png;base64,' + this.evento.numArray;
        this.evento.imagenEvento =
          this.sanitizer.bypassSecurityTrustUrl(objectURL);
        this.center['lat'] = null;
        this.center['lng'] = null;
        this.center['lat'] = this.evento.latitud;
        this.center['lng'] = this.evento.longitud;
        this.markerPositions.push({lat: this.evento.latitud, lng: this.evento.longitud})
      },
      error: (err) => {
        console.log('verEvento', err);
      },
    });
  };

  addMarker(event: google.maps.MapMouseEvent) {
    if (event.latLng != null) this.markerPositions.push(event.latLng.toJSON());
  }
}
