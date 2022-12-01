import { Component, OnInit } from '@angular/core';

import { RecomendacionesRepository } from 'src/app/recomendaciones/repositories/recomendaciones.repository';
import { TestAvance } from 'src/app/recomendaciones/interfaces/test-avance';
import { ActivatedRoute, Router } from '@angular/router';
import { RecomendacionRequest } from '../../interfaces/request/recomendacion.request';
import { CapacitacionDetRequest } from '../../interfaces/request/capacitacion-det.request';
import { TestAvanceRequest } from '../../interfaces/request/test-avance.request';
import { ToastService } from '../../../shared/services/toast.service';
import { CapacitacionDetalleRequest } from '../../interfaces/request/capacitaciondet.request';
import { RespuestaTestRequest } from '../../interfaces/request/respuesta-test.request';
import swal from 'sweetalert2';
import { CapacitacionResultadoRequest } from '../../interfaces/request/capacitacion-resultado.request';
import { calificacionResponse } from '../../interfaces/calificacion.response';

@Component({
  selector: 'app-test-avance',
  templateUrl: './test-avance.component.html',
  styleUrls: [],
})
export class TestAvanceComponent implements OnInit {
  idModulo: number;
  idRecomendacion: number;
  test: TestAvance;
  cuestionario: TestAvance[] = [];
  respuestaUsuario: RespuestaTestRequest[] = [];
  request: TestAvanceRequest;
  SwalAlert = swal;
  valor: boolean = true;
  msj: string;
  idCapacitacionResultado: number;
  nroCapacitacionesErradas: number;
  respuesta: calificacionResponse;
  calificacion: number;
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
    this.calificacion = 100;
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

  //
  enviarTest() {
    if (this.calificacion > 98) {
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
          id_modulo: this.test.capacitacionResultado.id_modulo,
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
          .subscribe((data: calificacionResponse) => {
            if (data.errores == 0) {
              this.calificacion = 0;
              return this.mensaje(
                1,
                '!Excelente¡',
                'Haz completado la evaluación de la recomendación que te propusimos revisar y haz obtenido',
                data.puntos_produce,
                'Puntos Produce',
                'e3',
                'white'
              );
            } else if (data.errores > 2) {
              this.calificacion = 3;
              return this.mensaje(
                2,
                '¡Una vez más! !',
                ' No hemos logrado comprobar tus conocimientos, vuelve a leer tu recomendación y pon a pruebas tus conocimientos en 59:00',
                0,
                '',
                'e2',
                '#089F42'
              );
            } else {
              this.calificacion = 2;
              return this.mensaje(
                2,
                '¡Sigue intentando!',
                ' No hemos logrado comprobar tus conocimientos',
                0,
                '',
                'e2',
                '#1D71B8'
              );
            }
          });
      } else {
        this.calificacion = 99;
        return this.mensaje(
          2,
          '¡Cuestionario Imcompleto!',
          ' Complete el cuestionario correctamente',
          0,
          '',
          'e2',
          '#089F42'
        );
      }
    }

    if (this.calificacion < 98) {
      return this.router.navigate([`/recomendaciones`]);
    }
  }
  mensaje(
    opcion: number,
    titulo: string,
    descripcion: string,
    puntos: number,
    pie_padina: string,
    imagen: string,
    color: string
  ) {
    if (opcion == 1) {
      this.SwalAlert.fire({
        background: color,
        imageUrl: 'assets/images/' + imagen + '.png',
        imageWidth: 520,
        imageHeight: 450,
        imageAlt: 'Custom image',
        title: titulo,
        html:
          '<p>' +
          descripcion +
          '</p>' +
          '<p>' +
          puntos +
          '</p>' +
          '<p>' +
          pie_padina +
          '</p>',
        confirmButtonText: `Regresar`,
      }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
          if (this.calificacion < 98) {
            this.router.navigate([`/recomendaciones`]);
          }
        }
      });
    } else if (opcion == 2) {
      this.SwalAlert.fire({
        background: color,
        imageUrl: 'assets/images/' + imagen + '.png',
        imageWidth: 520,
        imageHeight: 450,
        imageAlt: 'Custom image',
        title: titulo,
        html: '<p>' + descripcion + '</p>',
        confirmButtonText: `Regresar`,
      }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
          if (this.calificacion < 98) {
            this.router.navigate([`/recomendaciones`]);
          }
        }
      });
    }
  }
  regresar() {
    this.router.navigate([`/recomendaciones`]);
  }
}
