import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
})
export class NavMenuComponent implements OnInit {
  @Input() isAutenticated: boolean;
  @Input() verificacionAutodiagnostico: boolean;
  @Input() verificacionAutodiagnosticoHistorico: boolean;
  constructor() {}

  ngOnInit(): void {}
}
