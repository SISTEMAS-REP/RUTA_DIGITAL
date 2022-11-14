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
  verificacionDiagHistorico: boolean = false;
  verificacionDiag: boolean = false;
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
    debugger;
    this.isAutenticated;
    // this.repository.getUser().subscribe((user) => {
    //   debugger
    //   this.user = user;
    //   if( this.user != null){
    //     this.isCokies = true;
    //   }
    // });
    // if( this.user != null){
    //   this.user.id_usuario_extranet = 12594;
    //   this.isCokies = true;
    // }

    this.VerificarAutoDiagnosticoHistorico();
    this.VerificarAutoDiagnostico();
  }

  VerificarAutoDiagnosticoHistorico = () => {
    this.verificacionDiagHistorico = true;

    // var request: any = {
    //   id_usuario_extranet: 12594,
    // };
    // this.autodiagnostico
    // .VerificarAutoDiagnosticoHistorico(request)
    // .subscribe({
    //   next: (data : Array<any>) => {
    //     debugger
    //   },
    //   error: (err) => {
       
    //   },
    // });
  };

  VerificarAutoDiagnostico = () => {
    this.verificacionDiag = false;
  //   var request: any = {
  //     id_usuario_extranet: 12594,
  //   };
  //   this.autodiagnostico
  //   .VerificarAutoDiagnostico(request)
  //   .subscribe({
  //     next: (data : Array<any>) => {
  //       debugger
  //     },
  //     error: (err) => {
       
  //     },
  //   });
  };
















  fnEvento = () =>{
    if(this.isCokies){
      this.router.navigate(['/eventos']);
    }
    else{
      alert("debe iniciar sesion");
    }
  }

  fnCatalogoPremio = () =>{
    if(this.isCokies){
      this.router.navigate(['/catalogo-premios']);
    }
    else{
      alert("debe iniciar sesion");
    }
  }


  fnAutoDiagnosticoHistorico = () =>{
    if(this.isCokies){
      this.router.navigate(['/premios/premios-catalogo']);
    }
    else{
      alert("debe iniciar sesion");
    }
  }

  fnIniciarAutoDiagnostico = () =>{
    if(this.isCokies){
      this.router.navigate(['/premios/premios-catalogo']);
    }
    else{
      alert("debe iniciar sesion");
    }
  }

  fnResultado = () =>{
    if(this.isCokies){
      this.router.navigate(['/premios/premios-catalogo']);
    }
    else{
      alert("debe iniciar sesion");
    }
  }

  fnAvance = () =>{
    if(this.isCokies){
      this.router.navigate(['/premios/premios-catalogo']);
    }
    else{
      alert("debe iniciar sesion");
    }
  }

}
