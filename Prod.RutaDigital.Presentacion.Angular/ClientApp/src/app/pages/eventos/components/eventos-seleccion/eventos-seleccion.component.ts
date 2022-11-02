import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BannerRepository } from 'src/app/repositories/banner.repository';
// import { MapsAPILoader, MouseEvent } from "@agm/core";

@Component({
  selector: 'app-eventos-seleccion',
  templateUrl: './eventos-seleccion.component.html'
})
export class EventosSeleccionComponent implements OnInit {

  listEvento: Array<any>;
  Evento: any;
  id_filtro: number = null;
  id_evento: number = null;
  latitud: number = 0;
  longitud: number = 0;
  is_ver_mapa: Boolean = false;
  center: google.maps.LatLngLiteral = {
    lat: 0,
    lng: 0
  };
  
  zoom = 18;
  
  markerOptions: google.maps.MarkerOptions = {
    draggable: true
  };
  
  markerPositions: google.maps.LatLngLiteral[] = [];

  
  is_verdetalle: boolean = true;
  constructor(
    private bannerRepository: BannerRepository,
    private router: ActivatedRoute
  ) { 
    
  }

  ngOnInit(): void {
    this.router.params.subscribe((params) => {
      const id_evento = params["id"];
      this.id_evento = id_evento;
      this.VerEvento();
    });

    this.ListarEventos();
    this.VerEvento();
  }
   

  filter = (evento) =>{
    this.is_verdetalle = false;
    this.id_filtro = evento;
    this.ListarEventos();
  }

  SeleccionarEvento = (evento) =>{
    this.id_evento = evento;
    this.VerEvento();
  }

  ListarEventos = () => {
    var request: any = {
      id_evento: null,
      id_filtro: this.id_filtro
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

  VerEvento = () => {
    this.is_ver_mapa = false;
    var request: any = {
      id_evento: this.id_evento,
      id_filtro: null
    };

    this.bannerRepository
    .ListarEventos(request)
    .subscribe({
      next: (data : Array<any>) => {
        this.is_verdetalle = true;        
        this.is_ver_mapa = true;
        this.Evento = data[0];
        this.center['lat'] = null;
        this.center['lng'] = null;
        this.center['lat'] =this.Evento.latitud;
        this.center['lng'] =this.Evento.longitud;
      },
      error: (err) => {
       
      },
    });
  };



addMarker(event: google.maps.MapMouseEvent) {
    if (event.latLng != null) this.markerPositions.push(event.latLng.toJSON());
}
  
}
