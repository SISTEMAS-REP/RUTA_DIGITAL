import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { PremioNivelResponse, PremioPuntajeResponse, PremioResponse, PremioTipoResponse } from 'src/app/interfaces/premio';
import { BannerRepository } from 'src/app/repositories/banner.repository';

@Component({
  selector: 'app-premios-listado',
  templateUrl: './premios-listado.component.html'
})
export class PremiosListadoComponent implements OnInit {
  listTipoPremio : Array<any>;
  listNivelPremio : Array<any>;
  listPuntajePremio : Array<any>;
  listPremio : Array<any>;
  IdListCatalogo : number = 0;
  IdTipo : string = null;
  desdeSeleccionado: string = null;
  hastaSeleccionado: string = null;
  constructor(
    private premioRepository: BannerRepository,
    private sanitizer: DomSanitizer,
    private routerr: Router,
    private router: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.router.params.subscribe((params) => {
      const id = params["id"];
      var constante = id.split("-");
      if(constante.length == 1){
        this.IdListCatalogo = parseInt(constante[0]);
        this.IdTipo = null;
      }else{
        this.IdListCatalogo = null;
        this.IdTipo = constante[1];
      }
    });


    this.ListarTipoPremio();
    this.ListarPremioNivel();
    this.ListarNivelPremio();
    this.ListarPuntajePremio();
  }

  fnFiltrar = () =>{
    this.IdListCatalogo = null;
    this.ListarPremioNivel();
  }

  tipoSeleccionado: string = "";
  changeTipoPremio = (item) => {
    this.tipoSeleccionado = "";
    let element = <any> document.getElementsByName("tipoList");  
    element.forEach(element => {
      if(element.checked){
        this.tipoSeleccionado += element.id + ",";
      }
      
    });
    this.tipoSeleccionado = this.tipoSeleccionado.substr(0, this.tipoSeleccionado.length - 1);
    this.IdTipo = this.tipoSeleccionado;
    this.ListarPremioNivel();
  }

  ListarPremioNivel = () => {
    var request: any = {
      IdListCatalogo : this.IdListCatalogo,
      IdTipo: this.IdTipo,
      PuntosDesde: this.desdeSeleccionado,
      PuntosHasta: this.hastaSeleccionado
    };
    this.premioRepository
    .ListarPremio(request)
    .subscribe({
      next: (data : Array<PremioResponse>) => {
        
        this.listPremio = data;
        this.listPremio.forEach(element => {
          let objectURL = 'data:image/png;base64,' + element.numArray;
          element.imagenPremio = this.sanitizer.bypassSecurityTrustUrl(objectURL);
        });
      },
      error: (err) => {
       
      },
    });
  };
  
  loQuiero = (item) =>
  {
    this.routerr.navigate(['/premios/premios-detalle', item]);
  }

  ListarTipoPremio = () => {
    this.premioRepository
    .ListarTipoPremio()
    .subscribe({
      next: (data : Array<PremioTipoResponse>) => {
        this.listTipoPremio = data;
      },
      error: (err) => {
       
      },
    });
  };

  ListarNivelPremio = () => {
    this.premioRepository
    .ListarNivelPremio()
    .subscribe({
      next: (data : Array<PremioNivelResponse>) => {
        this.listNivelPremio = data;
      },
      error: (err) => {
       
      },
    });
  };

  ListarPuntajePremio = () => {
    this.premioRepository
    .ListarPuntajePremio()
    .subscribe({
      next: (data : Array<PremioPuntajeResponse>) => {
        this.listPuntajePremio = data;
      },
      error: (err) => {
       
      },
    });
  };
}
