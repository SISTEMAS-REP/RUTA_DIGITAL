import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

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
  ) { }

  ngOnInit(): void {
    if(this.id_usuario != null){
      this.isCokies = true;
    }
  }

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
