import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-nivel-modulo',
  templateUrl: './nivel-modulo.component.html',
  styleUrls: [],
})
export class NivelModuloComponent implements OnInit {
  @Input() modulo: string;
  @Input() orden: number;
  @Input() nivel: string;

  constructor() {}

  ngOnInit(): void {}
}
