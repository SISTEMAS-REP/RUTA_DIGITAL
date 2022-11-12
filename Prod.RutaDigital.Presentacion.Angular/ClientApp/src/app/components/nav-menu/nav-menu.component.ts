import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AutodiagnosticoRepository } from 'src/app/autodiagnostico/repositories/autodiagnostico.repository';
import { CounterRepository } from 'src/app/demo/repositories/counter.repository.ts';
import { ExtranetUser } from 'src/app/shared/interfaces/extranet-user';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html'
})
export class NavMenuComponent implements OnInit {
  @Input() isAutenticated: boolean;
  user: ExtranetUser;
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
    private autodiagnostico: AutodiagnosticoRepository,
    private repository: CounterRepository
  ) { }

  ngOnInit(): void {
    // this.repository.getUser().subscribe((user) => {
    //   debugger
    //   this.user = user;
    //   if( this.user != null){
    //     this.isCokies = true;
    //   }
    // });
    if( this.user != null){
      this.user.id_usuario_extranet = 12594;
      this.isCokies = true;
    }

    this.VerificarAutoDiagnosticoHistorico();
    this.VerificarAutoDiagnostico();
  }

  VerificarAutoDiagnosticoHistorico = () => {
    debugger
    var request: any = {
      id_usuario_extranet: 12594,
    };
    this.autodiagnostico
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
      id_usuario_extranet: 12594,
    };
    this.autodiagnostico
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