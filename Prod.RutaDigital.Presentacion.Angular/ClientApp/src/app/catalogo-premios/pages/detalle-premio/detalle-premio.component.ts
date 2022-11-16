import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { PremioResponse } from '../../interfaces/premio.response';
import { CatalogoPremiosRepository } from '../../catalogo-premios.repository';
import { AuthorizeService } from 'src/app/authorization/authorize.service';

@Component({
  selector: 'app-detalle-premio',
  templateUrl: './detalle-premio.component.html',
  styleUrls: [],
})
export class DetallePremioComponent implements OnInit {
  isAuthenticated: boolean = false;
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

  premio: PremioResponse;
  premios: PremioResponse[];

  id_premio: number;

  constructor(
    private repository: CatalogoPremiosRepository,
    private sanitizer: DomSanitizer,
    private Router: Router,
    private router: ActivatedRoute,
    private authorizeService: AuthorizeService,
  ) {
    this.authorizeService.isAuthenticated().subscribe((status) => {
      this.isAuthenticated = status;
    });
  }

  ngOnInit(): void {
    this.router.params.subscribe((params) => {
      const id_premio = params['premio'];
      this.id_premio = id_premio;
    });
    this.fnVerificacionCookies();
    this.listarPremio();
    this.listarDescubrePremios();
  }

  fnVerificacionCookies= () =>{
    if(this.isAuthenticated == false){
      alert("Debe iniciar sesion");
      this.Router.navigate(['/']);
    }
  }
  
  listarPremio = () => {
    var request: any = {
      CantReg: null,
      id_premio: this.id_premio,
    };
    this.repository.listarPremio(request).subscribe({
      next: (data: Array<PremioResponse>) => {
        this.premio = data[0];
        let objectURL = 'data:image/png;base64,' + this.premio.numArray;
        this.premio.imagenPremio =
          this.sanitizer.bypassSecurityTrustUrl(objectURL);
      },
      error: (err) => {},
    });
  };

  listarDescubrePremios = () => {
    var request: any = {
      CantReg: 10,
      IdListCatalogo: 3,
      id_premio: this.id_premio,
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
    this.id_premio = item;
    this.listarPremio();
    this.listarDescubrePremios();
  };
}
