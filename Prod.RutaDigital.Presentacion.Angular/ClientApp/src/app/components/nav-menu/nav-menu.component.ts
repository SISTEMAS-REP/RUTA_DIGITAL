import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BannerRepository } from 'src/app/repositories/banner.repository';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html'
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  isCokies: Boolean = false;
  id_usuario: number = null;
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  constructor(
    private router: Router,
    private menuRepository: BannerRepository
  ) { }

  ngOnInit(): void {
    if(this.id_usuario != null){
      this.isCokies = true;
    }
  }

  VerificarAutoDiagnosticoHistorico = () => {
    var request: any = {
      id_usuario_extranet: 10,
    };
    this.menuRepository
    .VerificarAutoDiagnosticoHistorico(request)
    .subscribe({
      next: (data : Array<any>) => {
        debugger
      },
      error: (err) => {
       
      },
    });
  };

  VerificarAutoDiagnostico = () => {
    var request: any = {
      id_usuario_extranet: 10,
    };
    this.menuRepository
    .VerificarAutoDiagnostico(request)
    .subscribe({
      next: (data : Array<any>) => {
        debugger
      },
      error: (err) => {
       
      },
    });
  };
















  fnEvento = () =>{
    if(this.isCokies){
      this.router.navigate(['/eventos']);
    }
    else{
      //mensaje
    }
  }

  fnCatalogoPemio = () =>{
    if(this.isCokies){
      this.router.navigate(['/premios/premios-catalogo']);
    }
    else{
      //mensaje
    }
  }


  fnAutoDiagnosticoHistorico = () =>{
    if(this.isCokies){
      this.router.navigate(['/premios/premios-catalogo']);
    }
    else{
      //mensaje
    }
  }

  fnIniciarAutoDiagnostico = () =>{
    if(this.isCokies){
      this.router.navigate(['/premios/premios-catalogo']);
    }
    else{
      //mensaje
    }
  }

  fnResultado = () =>{
    if(this.isCokies){
      this.router.navigate(['/premios/premios-catalogo']);
    }
    else{
      //mensaje
    }
  }

  fnAvance = () =>{
    if(this.isCokies){
      this.router.navigate(['/premios/premios-catalogo']);
    }
    else{
      //mensaje
    }
  }

}
