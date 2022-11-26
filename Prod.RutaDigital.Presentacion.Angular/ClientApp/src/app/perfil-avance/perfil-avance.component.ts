import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { CatalogoPremiosRepository } from '../catalogo-premios/catalogo-premios.repository';
import { PremioResponse } from '../catalogo-premios/interfaces/premio.response';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { CodGenero } from '../shared/enums/cod-genero.enum';
import { ExtranetUser } from '../shared/interfaces/extranet-user';
import { AutodiagnosticoRepository } from '../autodiagnostico/autodiagnostico.repository';
import { ResultadoAutodiagnostico } from '../autodiagnostico/interfaces/resultado-autodiagnostico';
import { CalendarEvent,CalendarDateFormatter,CalendarView} from 'angular-calendar';


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
  resultadoAutodiagnostico: ResultadoAutodiagnostico;
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
  ListNivelAutodiagnostico: Array<any>;
  ListCapacitando: Array<any>;
  ListNivel: Array<any>;

  view: CalendarView = CalendarView.Month;
  viewDate: Date = new Date();
  events: CalendarEvent[] = [];


  constructor(
    private catalogoPremios: CatalogoPremiosRepository,
    private sanitizer: DomSanitizer,
    private router: Router,
    private repository: AutodiagnosticoRepository
  ) {
    this.usuario = this.repository.obtenerUsuario();
  }

    ngOnInit(): void {
      this.repository
      .listarResultadoAutodiagnostico()
      .subscribe((data: ResultadoAutodiagnostico) => {
        this.resultadoAutodiagnostico = data;
      });
      
    this.listarPremioNuevo();
    this.ListNivelAutodiagnostico = [
      {
        numero_avance:"1",
        nivel:"Nivel Básico",
        tipo_nivel:"Marketing Digital"
      },
      {
        numero_avance:"2",
        nivel:"Nivel Incial",
        tipo_nivel:"Comercio electrónico"
      },
      {
        numero_avance:"3",
        nivel:"Nivel Básico",
        tipo_nivel:"Gestión Empresarial"
      },
      {
        numero_avance:"4",
        nivel:"Nivel Básico",
        tipo_nivel:"Finanzas"
      },
      {
        numero_avance:"5",
        nivel:"Nivel Incial",
        tipo_nivel:"Medios de pago"
      },
      {
        numero_avance:"6",
        nivel:"Nivel Incial",
        tipo_nivel:"Análisis de datos"
      },
    ];

    this.ListCapacitando = [
      {
        nivel:"Nivel Básico",
        tipo_nivel:"Gestión Empresarial",
        recomendacion:"Recomendación #4",
        porcentaje:"0%"
      },
      {
        nivel:"Nivel Incial",
        tipo_nivel:"Gestión Empresarial",
        recomendacion:"Recomendación #33",
        porcentaje:"10%"
      },
      {
        nivel:"Nivel Básico",
        tipo_nivel:"Gestión Empresarial",
        recomendacion:"Recomendación #44",
        porcentaje:"20%"
      },
      {
        nivel:"Nivel Incial",
        tipo_nivel:"Gestión Empresarial",
        recomendacion:"Recomendación #24",
        porcentaje:"30%"
      },
      {
        nivel:"Nivel Básico",
        tipo_nivel:"Gestión Empresarial",
        recomendacion:"Recomendación #785",
        porcentaje:"40%"
      },
    ];

    this.ListNivel = [
      {
        nivel:"Inicial",
        flag:false,
      },
      {
        nivel:"Básico",
        flag:true,
      },
      {
        nivel:"Intermedio",
        flag:false,
      },
      {
        nivel:"Avanzado",
        flag:false,
      },
      {
        nivel:"Experto",
        flag:false,
      }
    ];
  }

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
