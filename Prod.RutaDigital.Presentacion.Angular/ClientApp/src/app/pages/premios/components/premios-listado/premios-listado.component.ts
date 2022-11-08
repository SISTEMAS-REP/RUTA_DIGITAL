import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { PremioResponse, PremioTipoResponse } from 'src/app/interfaces/premio';
import { BannerRepository } from 'src/app/repositories/banner.repository';

@Component({
  selector: 'app-premios-listado',
  templateUrl: './premios-listado.component.html'
})
export class PremiosListadoComponent implements OnInit {

  listTipoPremio : Array<any>;
  listPremio : Array<any>;
  IdListCatalogo : number = 0;
  constructor(
    private premioRepository: BannerRepository,
    private sanitizer: DomSanitizer,
    private routerr: Router,
    private router: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.router.params.subscribe((params) => {
      const id_premio = params["id"];
      this.IdListCatalogo = id_premio;
    });


    this.ListarTipoPremio();
    this.ListarPremioNivel();
  }

  ListarPremioNivel = () => {
    var request: any = {
      CantReg: null,
      IdListCatalogo : this.IdListCatalogo
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
}
