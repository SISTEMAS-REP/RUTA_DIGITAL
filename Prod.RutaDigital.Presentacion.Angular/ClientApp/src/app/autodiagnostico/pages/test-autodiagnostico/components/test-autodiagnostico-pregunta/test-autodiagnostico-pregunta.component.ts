import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Pregunta } from 'src/app/autodiagnostico/interfaces/pregunta';
import { RespuestaRequest } from 'src/app/autodiagnostico/interfaces/request/respuesta.request';
import { Respuesta } from 'src/app/autodiagnostico/interfaces/respuesta';
import { TipoRespuesta } from 'src/app/shared/enums/tipo-respuesta.enum';
import { AutodiagnosticoRepository } from '../../../../autodiagnostico.repository';

@Component({
  selector: 'app-test-autodiagnostico-pregunta',
  templateUrl: './test-autodiagnostico-pregunta.component.html',
  styleUrls: [],
})
export class TestAutodiagnosticoPreguntasComponent implements OnInit {
  @Input() pregunta?: Pregunta;

  constructor(private repository: AutodiagnosticoRepository) {}

  ngOnInit(): void {}

  toogle($event: Respuesta) {
    const request: RespuestaRequest = {
      id_respuesta: $event.id_respuesta,
    };

    this.repository.actualizarRespuesta(request).subscribe({
      next: (data: Respuesta[]) => {
        if (data.length > 0) {
          this.pregunta.respuestas = data;
        } else {
          this.pregunta.respuestas = [...this.pregunta.respuestas];
        }
      },
      error: () => {
        this.pregunta.respuestas = [...this.pregunta.respuestas];
      },
    });
  }
}
