import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-seccion-premios',
  templateUrl: './seccion-premios.component.html',
})
export class SeccionPremiosComponent implements OnInit {
  constructor(private router: Router) {}

  ngOnInit(): void {}

  verPremios = () => {
    this.router.navigate(['/premios']);
  };
}
