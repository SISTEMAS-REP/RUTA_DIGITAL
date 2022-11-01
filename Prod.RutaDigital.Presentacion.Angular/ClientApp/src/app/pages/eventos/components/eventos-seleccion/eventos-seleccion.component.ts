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


  markerDragEnd($event: MouseEvent) {
    debugger
    // this.form.latitud = $event.coords.lat;
    // this.form.longitud = $event.coords.lng;
    // this.getAddress(this.form.latitud, this.form.longitud);
  }
  

}
