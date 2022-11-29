import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { ExtranetUser } from 'src/app/shared/interfaces/extranet-user';
import { CatalogoPremiosRepository } from '../../catalogo-premios.repository';
import { PremioTipoResponse } from '../../interfaces/premio-tipo.response';
import { PremioResponse } from '../../interfaces/premio.response';
import { PerfilAvanceRepository } from '../../../perfil-avance/perfil-avance.repository';
import { PerfilAvanceEstadisticaResponse } from 'src/app/perfil-avance/interfaces/perfil-avance-estadistica.response';


@Component({
  selector: 'app-inicio-catalogo-premios',
  templateUrl: './inicio-catalogo-premios.component.html',
  styleUrls: [],
})
export class InicioCatalogoPremiosComponent implements OnInit {
  usuario: ExtranetUser;
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

  tiposPremio: PremioTipoResponse[];
  nuevosPremios: PremioResponse[];
  nivelesPremios: PremioResponse[];
  estadisticaPerfil: PerfilAvanceEstadisticaResponse[];

  constructor(
    private repository: CatalogoPremiosRepository,
    private sanitizer: DomSanitizer,
    private router: Router,
    private repositoryPerfilAvance : PerfilAvanceRepository
  ) {
    this.usuario = this.repository.obtenerUsuario();
  }

  ngOnInit(): void {
    this.listarTipoPremio();
    this.listarPremioNuevo();
    this.listarPremioNivel();
    this.ListarEstadisticaPerfilAvance();
  }

  listarTipoPremio = () => {
    this.repository.listarTipoPremio().subscribe({
      next: (data: PremioTipoResponse[]) => {
        this.tiposPremio = data.map((tipoPremio) => {
          const objectURL = 'data:image/png;base64,' + tipoPremio.numArray;
          tipoPremio.imagenTipoPremio =
            this.sanitizer.bypassSecurityTrustUrl(objectURL);

          return tipoPremio;
        });
      },
      error: (err) => {},
    });
  };

  listarPremioNuevo = () => {
    var request: any = {
      CantReg: 10,
      IdListCatalogo: 1,
    };
    this.repository.listarPremio(request).subscribe({
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

  listarPremioNivel = () => {
    var request: any = {
      CantReg: 10,
      IdListCatalogo: 2,
    };
    this.repository.listarPremio(request).subscribe({
      next: (data: PremioResponse[]) => {
        this.nivelesPremios = data.map((nivelPremio) => {
          const objectURL = 'data:image/png;base64,' + nivelPremio.numArray;
          nivelPremio.imagenPremio =
            this.sanitizer.bypassSecurityTrustUrl(objectURL);

          let objectURLTipo =
            'data:image/png;base64,' + nivelPremio.fotoTipoArray;
          nivelPremio.imagenTipoPremio =
            this.sanitizer.bypassSecurityTrustUrl(objectURLTipo);
          return nivelPremio;
        });
      },
      error: (err) => {},
    });
  };

  ListarEstadisticaPerfilAvance = () => {
    debugger;
    var request: any = {
      id_usuario_extranet: this.usuario.id_usuario_extranet
    };
    this.repositoryPerfilAvance.ListarEstadisticaPerfilAvance(request).subscribe({
      next: (data: PerfilAvanceEstadisticaResponse[]) => {
        this.estadisticaPerfil = data;
      },
      error: (err) => {},
    });
  };

  loQuiero = (item) => {
    this.router.navigate(['/catalogo-premios/premio', item]);
  };
  verMas = (item) => {
    this.router.navigate(['/catalogo-premios/categoria', item]);
  };

  fnVerTipoPremio = (item) => {
    this.router.navigate(['/catalogo-premios/categoria', 'tipo-' + item]);
  };
}
