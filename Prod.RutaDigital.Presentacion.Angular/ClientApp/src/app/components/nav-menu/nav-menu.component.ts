import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AutodiagnosticoRepository } from 'src/app/auto-diagnostico/repositories/auto-diagnostico.repository';
import { ComponentsRepository } from 'src/app/components/repositories/components.repository.ts';
import { ExtranetUser } from 'src/app/shared/interfaces/extranet-user';
import { ToastService } from 'src/app/shared/services/toast.service';

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
    private repository: ComponentsRepository,
    private toastService: ToastService
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
      this.toastService.danger("Debe iniciar sesión", "Error");
    }
  }

  fnCatalogoPremio = () =>{
    if(this.isAutenticated){
      this.router.navigate(['/catalogo-premios']);
    }
    else{
      this.toastService.danger("Debe iniciar sesión", "Error");
    }
  }


  fnAutoDiagnosticoHistorico = () =>{
    if(this.isAutenticated){
      this.router.navigate(['/premios/premios-catalogo']);
    }
    else{
      this.toastService.danger("Debe iniciar sesión", "Error");
    }
  }

  fnAutoDiagnostico = () =>{
    if(this.isAutenticated){
      this.router.navigate(['/auto-diagnostico']);
    }
    else{
      this.toastService.danger("Debe iniciar sesión", "Error");
    }
  }

  fnResultado = () =>{
    if(this.isAutenticated){
      this.router.navigate(['/auto-diagnostico']);
    }
    else{
      this.toastService.danger("Debe iniciar sesión", "Error");
    }
  }

  fnAvance = () =>{
    if(this.isAutenticated){
      this.router.navigate(['']);
    }
    else{
      this.toastService.danger("Debe iniciar sesión", "Error");
    }
  }

}
