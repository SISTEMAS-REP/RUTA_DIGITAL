import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-autodiagnostico-preguntas',
  templateUrl: './test-autodiagnostico-preguntas.component.html',
  styleUrls: []
})
export class TestAutodiagnosticoPreguntasComponent implements OnInit {
  @Input() numero: number = 0;
  @Input() pregunta: string = "";
  constructor() { }

  ngOnInit(): void {
  }

}
