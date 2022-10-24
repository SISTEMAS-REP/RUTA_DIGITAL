import { Component, OnInit } from '@angular/core';
import { InicioRepository } from '../../repositories/inicio.repository';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: [],
})
export class InicioComponent implements OnInit {
  constructor(private repository: InicioRepository) {}

  ngOnInit(): void {}
}
