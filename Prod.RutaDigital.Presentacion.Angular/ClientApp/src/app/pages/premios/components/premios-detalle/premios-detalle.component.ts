import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { PremioResponse } from 'src/app/interfaces/premio';
import { BannerRepository } from 'src/app/repositories/banner.repository';

@Component({
  selector: 'app-premios-detalle',
  templateUrl: './premios-detalle.component.html'
})
export class PremiosDetalleComponent implements OnInit {
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
        items: 1
      },
      400: {
        items: 2
      },
      740: {
        items: 3
      },
      980: {
        items: 4
      }
    }
  }
  listPremio : PremioResponse;
  id_premio: number;
  constructor( private premioRepository: BannerRepository,
    private sanitizer: DomSanitizer,
    private router: ActivatedRoute,) { }

  ngOnInit(): void {
    this.router.params.subscribe((params) => {
      const id_premio = params["id"];
      this.id_premio = id_premio;
    });

    this.ListarPremio();
  }

  ListarPremio = () => {
    var request: any = {
      CantReg: null,
      id_premio: this.id_premio
    };
    this.premioRepository
    .ListarPremio(request)
    .subscribe({
      next: (data : Array<PremioResponse>) => {       
        this.listPremio = data[0];
        let objectURL = 'data:image/png;base64,' + this.listPremio.numArray;
        this.listPremio.imagenPremio = this.sanitizer.bypassSecurityTrustUrl(objectURL);
      },
      error: (err) => {
       
      },
    });
  };

}
