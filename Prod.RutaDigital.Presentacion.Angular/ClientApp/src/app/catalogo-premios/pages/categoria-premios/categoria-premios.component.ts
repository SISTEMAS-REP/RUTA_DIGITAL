import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { PremioNivelResponse } from '../../interfaces/premio-nivel.response';
import { PremioPuntajeResponse } from '../../interfaces/premio-puntaje.response';
import { PremioTipoResponse } from '../../interfaces/premio-tipo.response';
import { PremioResponse } from '../../interfaces/premio.response';
import { CatalogoPremiosRepository } from '../../catalogo-premios.repository';
import { AuthorizeService } from 'src/app/authorization/authorize.service';
import { ToastService } from 'src/app/shared/services/toast.service';

@Component({
  selector: 'app-categoria-premios',
  templateUrl: './categoria-premios.component.html',
  styleUrls: [],
})
export class CategoriaPremiosComponent implements OnInit {
  isAuthenticated: boolean = false;
  tiposPremio: PremioTipoResponse[];
  nivelesPremio: PremioNivelResponse[];
  puntajesPremio: PremioPuntajeResponse[];

  premios: PremioResponse[];

  IdListCatalogo: number = 0;
  IdTipo: string = null;

  desdeSeleccionado: number = 0;
  hastaSeleccionado: number = 0;

  page!: number;

  constructor(
    private repository: CatalogoPremiosRepository,
    private sanitizer: DomSanitizer,
    private Router: Router,
    private router: ActivatedRoute,
    private authorizeService: AuthorizeService,
    private toastService: ToastService
  ) {
    this.authorizeService.isAuthenticated().subscribe((status) => {
      this.isAuthenticated = status;
    });
  }

  ngOnInit(): void {
    this.router.params.subscribe((params) => {
      const id = params['categoria'];
      var constante = id.split('-');
      if (constante.length == 1) {
        this.IdListCatalogo = parseInt(constante[0]);
        this.IdTipo = null;
      } else {
        this.IdListCatalogo = null;
        this.IdTipo = constante[1];
      }
    });
    this.fnVerificacionCookies();
    this.listarTipoPremio();
    this.listarPremioNivel();
    this.listarNivelPremio();
    this.listarPuntajePremio();
  }

  fnVerificacionCookies= () =>{
    if(this.isAuthenticated == false){
      this.toastService.danger("Debe iniciar sesión", "Error");
      this.Router.navigate(['/']);
    }
  }

  fnFiltrar = () => {
    this.IdListCatalogo = null;
    this.listarPremioNivel();
  };

  tipoSeleccionado: string = '';
  changeTipoPremio = (item) => {
    this.tipoSeleccionado = '';
    let element = <any>document.getElementsByName('tipoList');
    element.forEach((element) => {
      if (element.checked) {
        this.tipoSeleccionado += element.id + ',';
      }
    });
    this.tipoSeleccionado = this.tipoSeleccionado.substr(
      0,
      this.tipoSeleccionado.length - 1
    );
    this.IdTipo = this.tipoSeleccionado;
    this.IdListCatalogo = null;
    this.listarPremioNivel();
  };

  nivelSeleccionado: string = '';
  changeNivelPremio = (item) => {
    this.nivelSeleccionado = '';
    let element = <any>document.getElementsByName('nivelList');
    element.forEach((element) => {
      if (element.checked) {
        this.nivelSeleccionado += element.id + ',';
      }
    });
    this.nivelSeleccionado = this.nivelSeleccionado.substr(
      0,
      this.nivelSeleccionado.length - 1
    );
    this.IdListCatalogo = null;
    this.listarPremioNivel();
  };

  listarPremioNivel = () => {
    var request: any = {
      IdListCatalogo: this.IdListCatalogo,
      IdTipo: this.IdTipo,
      IdNivel: this.nivelSeleccionado,
      PuntosDesde: this.desdeSeleccionado,
      PuntosHasta: this.hastaSeleccionado,
    };
    this.repository.listarPremio(request).subscribe({
      next: (data: PremioResponse[]) => {
        this.premios = data.map((premio) => {
          const objectURL = 'data:image/png;base64,' + premio.numArray;
          premio.imagenPremio =
            this.sanitizer.bypassSecurityTrustUrl(objectURL);

          let objectURLTipo = 'data:image/png;base64,' + premio.fotoTipoArray;
          premio.imagenTipoPremio =
            this.sanitizer.bypassSecurityTrustUrl(objectURLTipo);
          return premio;
        });
      },
      error: (err) => {},
    });
  };

  loQuiero = (item) => {
    this.Router.navigate(['/catalogo-premios/premio', item]);
  };

  listarTipoPremio = () => {
    this.repository.listarTipoPremio().subscribe({
      next: (data: PremioTipoResponse[]) => {
        this.tiposPremio = data;
      },
      error: (err) => {},
    });
  };

  listarNivelPremio = () => {
    this.repository.listarNivelPremio().subscribe({
      next: (data: PremioNivelResponse[]) => {
        this.nivelesPremio = data;
      },
      error: (err) => {},
    });
  };

  listarPuntajePremio = () => {
    this.repository.listarPuntajePremio().subscribe({
      next: (data: PremioPuntajeResponse[]) => {
        this.puntajesPremio = data;
      },
      error: (err) => {},
    });
  };

  fnLimpiarFiltros = () => {
    this.IdListCatalogo = null;
    this.IdTipo = null;
    this.nivelSeleccionado = null;
    this.desdeSeleccionado = null;
    this.hastaSeleccionado = null;

    let elementNivel = <any>document.getElementsByName('nivelList');
    let elementTipo = <any>document.getElementsByName('tipoList');

    elementNivel.forEach((element) => {
      element.checked = false;
    });

    elementTipo.forEach((element) => {
      element.checked = false;
    });

    this.listarPremioNivel();
  };
}
