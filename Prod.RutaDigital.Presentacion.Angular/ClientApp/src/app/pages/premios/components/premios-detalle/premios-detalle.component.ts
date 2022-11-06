import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
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
  constructor( private premioRepository: BannerRepository,
    private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.ListarPremio();
  }

  ListarPremio = () => {
    this.premioRepository
    .ListarPremio()
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
