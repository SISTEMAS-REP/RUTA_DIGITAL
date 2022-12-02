import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { CatalogoPremiosRepository } from '../catalogo-premios/catalogo-premios.repository';
import { PremioResponse } from '../catalogo-premios/interfaces/premio.response';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { CodGenero } from '../shared/enums/cod-genero.enum';
import { ExtranetUser } from '../shared/interfaces/extranet-user';
import { CalendarEvent,CalendarDateFormatter,CalendarView} from 'angular-calendar';
import { PerfilAvanceRepository } from './perfil-avance.repository';
import { PerfilAvanceEstadisticaResponse } from './interfaces/perfil-avance-estadistica.response';
import { PerfilAvancePremioConsumoResponse } from './interfaces/perfil-avance-premio-consumo.response';
import { ResultadoPerfil } from './interfaces/resultado-perfil';
import { setHours, setMinutes } from 'date-fns';



@Component({
  selector: 'app-perfil-avance',
  templateUrl: './perfil-avance.component.html',
  providers: [
    {
      provide: CalendarDateFormatter
    },
  ],
})
export class PerfilAvanceComponent implements OnInit {
  usuario: ExtranetUser;
  resultadoPerfilAvance: ResultadoPerfil;
  customOptions: OwlOptions = {
    loop: true,
    mouseDrag: true,
    touchDrag: true,
    pullDrag: false,
    autoplay: true,
    dots: false,
    navSpeed: 700,
    navText: ['', ''],
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
      940: {
        items: 4,
      },
    },
  };

  nuevosPremios: PremioResponse[];
  estadisticaPerfil: PerfilAvanceEstadisticaResponse[];
  premioConsumo: PerfilAvancePremioConsumoResponse[];
  ListarCapacitando: Array<any>;
  view: CalendarView = CalendarView.Month;
  viewDate: Date = new Date();
  events: CalendarEvent[] = [];

  constructor(
    private catalogoPremios: CatalogoPremiosRepository,
    private sanitizer: DomSanitizer,
    private router: Router,
    private repositoryPerfilAvance : PerfilAvanceRepository
  ) {
  }

    ngOnInit(): void {
    this.usuario = this.repositoryPerfilAvance.obtenerUsuario();
      this.repositoryPerfilAvance
      .ListarResultadoPerfilAvance()
      .subscribe((data: ResultadoPerfil) => {
        this.resultadoPerfilAvance = data;
      });
      
    this.listarPremioNuevo();
    this.ListarEstadisticaPerfilAvance();
    this.ListarPremioConsumoPerfilAvance();
    this.ListarCapacitacionPerfilAvance();
  }


  ListarEstadisticaPerfilAvance = () => {
    var request: any = {
      id_usuario_extranet: this.usuario.id_usuario_extranet
    };
    this.repositoryPerfilAvance.ListarEstadisticaPerfilAvance(request).subscribe({
      next: (data: PerfilAvanceEstadisticaResponse[]) => {
        this.estadisticaPerfil = data;
        this.viewDate = this.estadisticaPerfil[0].fecha_inicio_capacitacion;
        this.events = [{
          title: 'No event end date',
          start: setHours(setMinutes(new Date(this.viewDate), 0), 0),
          color: {
            primary:"0000",
            secondary:"0000"
          }
        }]

      },
      error: (err) => {},
    });
  };

  ListarCapacitacionPerfilAvance = () => {
    var request: any = {
      id_usuario_extranet: this.usuario.id_usuario_extranet
    };
    this.repositoryPerfilAvance.ListarCapacitacionPerfilAvance(request).subscribe({
      next: (data: any[]) => {
        this.ListarCapacitando = data;
      },
      error: (err) => {},
    });
  };

  ListarPremioConsumoPerfilAvance = () => {
    var request: any = {
      id_usuario_extranet: this.usuario.id_usuario_extranet
    };
    this.repositoryPerfilAvance.ListarPremioConsumoPerfilAvance(request).subscribe({
      next: (data: any[]) => {
        this.premioConsumo = data.map((premio) => {
          const objectURL = 'data:image/png;base64,' + premio.numArray;
          premio.imagenPremio =
            this.sanitizer.bypassSecurityTrustUrl(objectURL);
          return premio;
        });
      },
      error: (err) => {},
    });
  };

  listarPremioNuevo = () => {
    var request: any = {
      CantReg: 4,
      IdListCatalogo: 1,
    };
    this.catalogoPremios.listarPremio(request).subscribe({
      next: (data: PremioResponse[]) => {
        this.nuevosPremios = data.map((nuevoPremio) => {
          const objectURL = 'data:image/png;base64,' + nuevoPremio.numArray;
          nuevoPremio.imagenPremio =
            this.sanitizer.bypassSecurityTrustUrl(objectURL);

          let objectURLTipo =
            'data:image/png;base64,' + nuevoPremio.fotoTipoArray;
          nuevoPremio.imagenTipoPremio =
            this.sanitizer.bypassSecurityTrustUrl(objectURLTipo);
          return nuevoPremio;
        });
      },
      error: (err) => {},
    });
  };

  loQuiero = (item) => {
    this.router.navigate(['/catalogo-premios/premio', item]);
  };

  verPremios = () => {
    this.router.navigate(['/catalogo-premios']);
  };

  mostrarTituloPorGenero(codGenero: string) {
    var articulo = CodGenero.MASCULINO.toString() == codGenero ? 'El' : 'La';
    var sustantivo =
      CodGenero.MASCULINO.toString() == codGenero
        ? 'Emprendedor'
        : 'Emprendedora';

    return `${articulo} ${sustantivo}`;
  }
}
