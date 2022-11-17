import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ExtranetUser } from '../shared/interfaces/extranet-user';
import { AutodiagnosticoRepository } from 'src/app/auto-diagnostico/repositories/auto-diagnostico.repository';
import { AuthorizeService } from '../authorization/authorize.service';
import { ToastService } from '../shared/services/toast.service';


@Component({
  selector: 'app-auto-diagnostico',
  templateUrl: './auto-diagnostico.component.html',
  styleUrls: []
})
export class AutoDiagnosticoComponent implements OnInit {
  isAuthenticated: boolean = false;
  user: ExtranetUser;
  id_usuario_extranet: number = null;
  isResultado: boolean = false;

  constructor(
    private router: Router,
    private repository: AutodiagnosticoRepository,
    private authorizeService: AuthorizeService,
    private toastService: ToastService
  ) { 
    this.authorizeService.isAuthenticated().subscribe((status) => {
      this.isAuthenticated = status;
    });
  }

  ngOnInit(): void {
    this.repository.getUser().subscribe((user) => {
      this.id_usuario_extranet = user.id_usuario_extranet;
    });
    this.fnVerificacionResultado();
  }

  fnVerificacionResultado = () =>{
    if(this.isAuthenticated){
      if(this.isResultado){
        this.router.navigate(['/auto-diagnostico/resultado-test']);
      }
      else{
        this.router.navigate(['/auto-diagnostico/test']);
      }
    }
    else{
      this.toastService.danger("Debe iniciar sesión", "Error");
      this.router.navigate(['/']);
    }
  }
}
