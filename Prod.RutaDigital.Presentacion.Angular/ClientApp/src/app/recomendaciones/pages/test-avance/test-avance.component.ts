import { Component, OnInit } from '@angular/core';
import { Swal } from 'sweetalert2/dist/sweetalert2.js';
import { RecomendacionesRepository } from 'src/app/recomendaciones/repositories/recomendaciones.repository';
import { TestAvance } from 'src/app/recomendaciones/interfaces/test-avance';
import { ActivatedRoute, Router } from '@angular/router';
import { RecomendacionRequest } from '../../interfaces/request/recomendacion.request';
import { CapacitacionDetRequest } from '../../interfaces/request/capacitacion-det.request';
import { TestAvanceRequest } from '../../interfaces/request/test-avance.request';
import { ToastService } from '../../../shared/services/toast.service';
import { CapacitacionDetalleRequest } from '../../interfaces/request/capacitaciondet.request';
import { RespuestaTestRequest } from '../../interfaces/request/respuesta-test.request';

@Component({
  selector: 'app-test-avance',
  templateUrl: './test-avance.component.html',
  styleUrls: [],
})
export class TestAvanceComponent implements OnInit {
  idRecomendacion: number;
  test: TestAvance;
  cuestionario: TestAvance[] = [];
  respuestaUsuario: RespuestaTestRequest[] = [];
  request: TestAvanceRequest;
  SwalAlert: Swal;
  valor: boolean = true;
  
  constructor(
    private router: Router,
    private repository: RecomendacionesRepository,
    private activatedRoute: ActivatedRoute,
    private toastService: ToastService
  ) {
    this.activatedRoute.params.subscribe((params) => {
      console.log('params', params);
      this.idRecomendacion = params['idRecomendacion'];
    });
  }
  ngOnInit(): void {
    this.listarTestAvance();
  }

  listarTestAvance() {
    var request: RecomendacionRequest = {
      id_recomendacion: this.idRecomendacion,
    };
    this.repository.listarTestAvance(request).subscribe({
      next: (data: TestAvance) => {
        this.test = data;
      },
    });
  }
  toogle($event: RespuestaTestRequest) {
    console.log('TestAvanceComponent/toogle', $event);
    this.respuestaUsuario.push($event);
  }
  enviarTest() {
    var respuesta_1: number = 0;
    var respuesta_2: number = 0;
    var respuesta_3: number = 0;
    var aternativa_1: number = 0;
    var aternativa_2: number = 0;
    var aternativa_3: number = 0;
    var index_1: number = 0;
    var index_2: number = 0;
    var index_3: number = 0;
    var peso_1: number = 0;
    var peso_2: number = 0;
    var peso_3: number = 0;

    this.cuestionario.push(this.test);
    for (let f = 0; f < this.respuestaUsuario.length; f++) {
      if (respuesta_1 === 0) {
        index_1 = f;
        respuesta_1 = this.respuestaUsuario[f].id_pregunta;
        aternativa_1 = this.respuestaUsuario[f].id_alternativa;
        peso_1 = this.respuestaUsuario[f].peso;
      } else if (this.respuestaUsuario[f].id_pregunta === respuesta_1) {
        index_1 = f;
        aternativa_1 = this.respuestaUsuario[f].id_alternativa;
        peso_1 = this.respuestaUsuario[f].peso;
      } else if (respuesta_2 === 0) {
        index_2 = f;
        respuesta_2 = this.respuestaUsuario[f].id_pregunta;
        aternativa_2 = this.respuestaUsuario[f].id_alternativa;
        peso_2 = this.respuestaUsuario[f].peso;
      } else if (this.respuestaUsuario[f].id_pregunta === respuesta_2) {
        index_2 = f;
        aternativa_2 = this.respuestaUsuario[f].id_alternativa;
        peso_2 = this.respuestaUsuario[f].peso;
      } else if (respuesta_3 === 0) {
        index_3 = f;
        aternativa_3 = this.respuestaUsuario[f].id_alternativa;
        respuesta_3 = this.respuestaUsuario[f].id_pregunta;
        peso_3 = this.respuestaUsuario[f].peso;
      } else if (this.respuestaUsuario[f].id_pregunta === respuesta_3) {
        index_3 = f;
        aternativa_3 = this.respuestaUsuario[f].id_alternativa;
        peso_3 = this.respuestaUsuario[f].peso;
      }
    }
    if (respuesta_1 != 0 && respuesta_2 != 0 && respuesta_3 != 0) {
      var request: CapacitacionDetalleRequest = {
        id_capacitacion_resultado:
          this.test.capacitacionResultado.id_capacitacion_resultado,
        respuestas: [
          {
            id_alternativa: aternativa_1,
            id_pregunta: respuesta_1,
            respuesta: this.valor,
            peso: peso_1,
          },
          {
            id_alternativa: aternativa_2,
            id_pregunta: respuesta_2,
            respuesta: this.valor,
            peso: peso_2,
          },
          {
            id_alternativa: aternativa_3,
            id_pregunta: respuesta_3,
            respuesta: this.valor,
            peso: peso_3,
          },
        ],
      };
    }
    console.log(request);
    if (respuesta_1 != 0 && respuesta_2 != 0 && respuesta_3 != 0) {
      return this.repository
        .procesarAvance(request)
        .subscribe((data: number) => {
          this.toastService.success(
            'Test de autodiagnóstico finalizado correctamente'
          );
          this.regresar();
        });
    } else {
      return console.log('marque todas las alternativas');
    }
  }

  regresar() {
    this.router.navigate([`/recomendaciones`]);
  }
}
