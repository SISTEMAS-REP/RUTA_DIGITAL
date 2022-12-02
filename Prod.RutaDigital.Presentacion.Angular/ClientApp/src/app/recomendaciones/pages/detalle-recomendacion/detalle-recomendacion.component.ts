import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { RecomendacionesRepository } from '../../repositories/recomendaciones.repository';
import { ActivatedRoute, Router } from '@angular/router';
import { CapacitacionResultadoRequest } from '../../interfaces/request/capacitacion-resultado.request';
import { Recomendacion } from '../../interfaces/recomendacion';
import { Modulo } from 'src/app/autodiagnostico/interfaces/modulo';
import { RecomendacionRequest } from '../../interfaces/request/recomendacion.request';

@Component({
  selector: 'app-detalle-recomendacion',
  templateUrl: './detalle-recomendacion.component.html',
  styleUrls: [],
})
export class DetalleRecomendacionComponent implements OnInit {
  idCapacitacionResultado: number;
  recomendacion?: Recomendacion;
  sanitizedURL: DomSanitizer;
  calificacion_actual: number;
  toastService: any;

  constructor(
    private router: Router,
    private repository: RecomendacionesRepository,
    private sanitizer: DomSanitizer,
    private activatedRoute: ActivatedRoute
  ) {
    this.activatedRoute.params.subscribe((params) => {
      console.log('params', params);
      this.idCapacitacionResultado = params['idCapacitacionResultado'];
    });
  }

  ngOnInit(): void {
    this.listarRecomendacion();
  }

  regresarARecomendaciones() {
    this.router.navigate([
      `/recomendaciones/modulo/${this.recomendacion.id_modulo}`,
    ]);
  }

  link(item: string) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(item);
  }

  validarInicio() {
    if (!this.recomendacion?.fecha_inicio) {
      this.iniciarCapacitacion();
    }
  }

  verTest() {
    const request: RecomendacionRequest = {
      id_recomendacion: this.recomendacion?.id_recomendacion,
    };

    this.repository
      .validarCapacitacionesErradas(request)
      .subscribe((data: number) => {
        if (data < 3) {
          this.router.navigate([
            `/recomendaciones/${this.recomendacion.id_recomendacion}/test`,
          ]);
        }
      });
  }

  listarRecomendacion() {
    var request: CapacitacionResultadoRequest = {
      id_capacitacion_resultado: this.idCapacitacionResultado,
    };

    this.repository.listarRecomendacion(request).subscribe({
      next: (data: Recomendacion) => {
        this.recomendacion = data;

        this.validarInicio();
      },
      error: (err) => {},
    });
  }

  llenarCalificacion(id: number) {
    this.calificacion_actual = id;
  }

  validarCalificacion(calificacion: number) {
    if (!this.calificacion_actual) {
      this.calificarCapacitacion(calificacion);
    }
  }

  calificarCapacitacion(calificacion: number) {
    const request: CapacitacionResultadoRequest = {
      id_capacitacion_resultado: this.idCapacitacionResultado,
      calificacion: calificacion,
    };
    this.repository.calificarCapacitacion(request).subscribe({
      next: (data: number) => {
        this.calificacion_actual = calificacion;
      },
    });
  }

  iniciarCapacitacion() {
    const request: CapacitacionResultadoRequest = {
      id_capacitacion_resultado: this.idCapacitacionResultado,
    };
    this.repository.iniciarCapacitacion(request).subscribe({
      next: (data: number) => {},
    });
  }
}
