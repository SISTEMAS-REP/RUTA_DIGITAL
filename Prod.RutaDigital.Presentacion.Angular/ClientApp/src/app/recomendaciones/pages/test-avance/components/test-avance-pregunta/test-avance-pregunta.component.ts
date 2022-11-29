import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Alternativa } from 'src/app/autodiagnostico/interfaces/alternativa';
import { Pregunta } from 'src/app/autodiagnostico/interfaces/pregunta';
import { CapacitacionDetRequest } from 'src/app/recomendaciones/interfaces/request/capacitacion-det.request';
import { RespuestaTestRequest } from 'src/app/recomendaciones/interfaces/request/respuesta-test.request';

@Component({
  selector: 'app-test-avance-pregunta',
  templateUrl: './test-avance-pregunta.component.html',
  styleUrls: [],
})
export class TestAvancePreguntaComponent implements OnInit {
  @Input() pregunta?: Pregunta;
  @Output() onToogle: EventEmitter<RespuestaTestRequest> = new EventEmitter();

  constructor() { }

  ngOnInit(): void { }

  toogle(alternativa: Alternativa) {
    //console.log('toogle', capacitacionDet)
    const capacitacionDet = alternativa as RespuestaTestRequest;
    this.onToogle.emit(capacitacionDet);
  }
}
