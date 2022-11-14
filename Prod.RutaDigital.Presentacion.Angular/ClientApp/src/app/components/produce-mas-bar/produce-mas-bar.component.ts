import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {
  ApplicationPaths,
  QueryParameterNames,
} from 'src/app/authorization/authorization.constants';

@Component({
  selector: 'app-produce-mas-bar',
  templateUrl: './produce-mas-bar.component.html',
})
export class ProduceMasBarComponent implements OnInit {
  @Input() isAutenticated: boolean;

  constructor(private router: Router) {}

  ngOnInit(): void {}

  loginPersonaNatural() {
    this.router.navigate(ApplicationPaths.LoginPersonPathComponents);
  }

  loginPersonaJuridica() {
    this.router.navigate(ApplicationPaths.LoginCompanyPathComponents);
  }

  profile() {
    this.router.navigate(ApplicationPaths.ProfilePathComponents);
  }

  logout() {
    this.router.navigate(ApplicationPaths.LogOutPathComponents);
  }
}
