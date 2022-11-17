import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorizeService } from '../authorization/authorize.service';
import { ToastService } from '../shared/services/toast.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: [],
})
export class EventosComponent implements OnInit {
  isAuthenticated: boolean = false;

  constructor(
    private router: Router,
    private authorizeService: AuthorizeService,
    private toastService: ToastService
  ) {
    this.authorizeService.isAuthenticated().subscribe((status) => {
      this.isAuthenticated = status;
    });
  }

  ngOnInit(): void {
    this.fnVerificacionCookies();
  }

  fnVerificacionCookies= () =>{
    debugger;
    if(this.isAuthenticated){
        this.router.navigate(['/eventos']);
    }
    else{
      this.toastService.danger("Debe iniciar sesión", "Error");
      this.router.navigate(['/']);
    }
  }
}
