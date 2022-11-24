import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-nivel-madurez',
  templateUrl: './nivel-madurez.component.html',
  styleUrls: [],
})
export class NivelMadurezComponent implements OnInit {
  @Input() nivel: string;
  @Input() seleccionado: boolean;

  constructor() {}

  ngOnInit(): void {}
}
