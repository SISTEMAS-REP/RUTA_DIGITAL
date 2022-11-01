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
  latitud: number = -12.011307;
  longitud: number = -77.0033325;
  
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
        debugger
        // if(data.length == 0){
        //   this.is_verdetalle = false;
        // }
        // else{
        //   this.is_verdetalle = true;
        // }
        this.listEvento = data;
      },
      error: (err) => {
       
      },
    });
  };

  VerEvento = () => {
    var request: any = {
      id_evento: this.id_evento,
      id_filtro: null
    };

    this.bannerRepository
    .ListarEventos(request)
    .subscribe({
      next: (data : Array<any>) => {
        this.is_verdetalle = true;
        this.Evento = data[0];
      },
      error: (err) => {
       
      },
    });
  };

center: google.maps.LatLngLiteral = {
    lat: this.latitud,
    lng: this.longitud,   
};
zoom = 18;
markerOptions: google.maps.MarkerOptions = {
    draggable: true
};
markerPositions: google.maps.LatLngLiteral[] = [];
addMarker(event: google.maps.MapMouseEvent) {
    if (event.latLng != null) this.markerPositions.push(event.latLng.toJSON());
}
  
}
