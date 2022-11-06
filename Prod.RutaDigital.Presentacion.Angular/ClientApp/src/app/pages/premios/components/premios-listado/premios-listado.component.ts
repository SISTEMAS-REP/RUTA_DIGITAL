import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { PremioResponse } from 'src/app/interfaces/premio';
import { BannerRepository } from 'src/app/repositories/banner.repository';

@Component({
  selector: 'app-premios-listado',
  templateUrl: './premios-listado.component.html'
})
export class PremiosListadoComponent implements OnInit {

  listPremio : Array<any>;
  constructor(
    private premioRepository: BannerRepository,
    private sanitizer: DomSanitizer
  ) { }

  ngOnInit(): void {
    this.ListarPremioNivel();
  }

  ListarPremioNivel = () => {
    this.premioRepository
    .ListarPremio()
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

}
