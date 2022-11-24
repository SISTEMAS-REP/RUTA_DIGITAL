import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
//import { AutodiagnosticoRepository } from 'src/app/autodiagnostico/repositories/resultado-autodiagnostico.repository';
import { ExtranetUser } from 'src/app/shared/interfaces/extranet-user';
import { ToastService } from 'src/app/shared/services/toast.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
})
export class NavMenuComponent implements OnInit {
  @Input() isAutenticated: boolean;

  user: ExtranetUser;
  id_usuario_extranet: number = null;
  //verificacionDiagHistorico: boolean = false;
  verificacionAutodiagnostico: boolean = false;

  constructor(private router: Router, private toastService: ToastService) {}

  ngOnInit(): void {}
}
