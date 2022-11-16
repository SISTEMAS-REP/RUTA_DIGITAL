import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AutodiagnosticoRepository } from 'src/app/auto-diagnostico/repositories/auto-diagnostico.repository';
import { ComponentsRepository } from 'src/app/components/repositories/components.repository.ts';
import { ExtranetUser } from 'src/app/shared/interfaces/extranet-user';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html'
})
export class NavMenuComponent implements OnInit {
  @Input() isAutenticated: boolean;
  user: ExtranetUser;
  id_usuario_extranet: number = null;
  verificacionDiagHistorico: boolean = false;
  verificacionDiag: boolean = false;

  constructor(
    private router: Router,
    private autodiagnostico: AutodiagnosticoRepository,
    private repository: ComponentsRepository
  ) { }

  ngOnInit(): void {
    this.repository.getUser().subscribe((user) => {
      this.id_usuario_extranet = user.id_usuario_extranet;
      if( this.id_usuario_extranet != null){
        this.VerificarAutoDiagnosticoHistorico();
        this.VerificarAutoDiagnostico();
      }
    });
  }

  VerificarAutoDiagnosticoHistorico = () => {
    var request: any = {
      id_usuario_extranet: this.id_usuario_extranet,
    };
    this.autodiagnostico
    .VerificarAutoDiagnosticoHistorico(request)
    .subscribe({
      next: (data : any) => {
        this.verificacionDiagHistorico = data.flag;
      },
      error: (err) => {
       
      },
    });
  };

  VerificarAutoDiagnostico = () => {
    var request: any = {
      id_usuario_extranet: this.id_usuario_extranet,
    };
    this.autodiagnostico
    .VerificarAutoDiagnostico(request)
    .subscribe({
      next: (data : any) => {
        this.verificacionDiag = data.flag;
      },
      error: (err) => {
       
      },
    });
  };


  fnEvento = () =>{
    if(this.isAutenticated){
      this.router.navigate(['/eventos']);
    }
    else{
      alert("Debe iniciar sesion");
    }
  }

  fnCatalogoPremio = () =>{
    if(this.isAutenticated){
      this.router.navigate(['/catalogo-premios']);
    }
    else{
      alert("Debe iniciar sesion");
    }
  }


  fnAutoDiagnosticoHistorico = () =>{
    if(this.isAutenticated){
      this.router.navigate(['/premios/premios-catalogo']);
    }
    else{
      alert("Debe iniciar sesion");
    }
  }

  fnAutoDiagnostico = () =>{
    if(this.isAutenticated){
      this.router.navigate(['/auto-diagnostico']);
    }
    else{
      alert("Debe iniciar sesion");
    }
  }

  fnResultado = () =>{
    if(this.isAutenticated){
      this.router.navigate(['/auto-diagnostico']);
    }
    else{
      alert("Debe iniciar sesion");
    }
  }

  fnAvance = () =>{
    if(this.isAutenticated){
      this.router.navigate(['']);
    }
    else{
      alert("Debe iniciar sesion");
    }
  }

}
