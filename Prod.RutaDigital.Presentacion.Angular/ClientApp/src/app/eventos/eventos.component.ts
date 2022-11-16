import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorizeService } from '../authorization/authorize.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: [],
})
export class EventosComponent implements OnInit {
  isAuthenticated: boolean = false;

  constructor(
    private router: Router,
    private authorizeService: AuthorizeService
  ) {
    this.authorizeService.isAuthenticated().subscribe((status) => {
      this.isAuthenticated = status;
    });
  }

  ngOnInit(): void {
    this.fnVerificacionCookies();
  }

  fnVerificacionCookies= () =>{
    if(this.isAuthenticated){
        this.router.navigate(['/eventos']);
    }
    else{
      alert("Debe iniciar sesion");
      this.router.navigate(['/']);
    }
  }
}
