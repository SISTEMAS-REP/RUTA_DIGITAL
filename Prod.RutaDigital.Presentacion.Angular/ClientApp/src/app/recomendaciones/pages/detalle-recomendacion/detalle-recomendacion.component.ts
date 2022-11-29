import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { RecomendacionesRepository } from '../../repositories/recomendaciones.repository';
import { ActivatedRoute, Router } from '@angular/router';
import { CapacitacionResultadoRequest } from '../../interfaces/request/capacitacion-resultado.request';
import { Recomendacion } from '../../interfaces/recomendacion';
import { Modulo } from 'src/app/autodiagnostico/interfaces/modulo';

@Component({
  selector: 'app-detalle-recomendacion',
  templateUrl: './detalle-recomendacion.component.html',
  styleUrls: [],
})
export class DetalleRecomendacionComponent implements OnInit {
  idCapacitacionResultado: number;
  recomendacion?: Recomendacion;
  sanitizedURL: DomSanitizer;
  modulos: Modulo[];
  calificacion: number;
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
    this.listarCapacitaciones();

  }

  listarCapacitaciones() {
    this.repository.listarCapacitaciones().subscribe((data: Modulo[]) => {
      this.modulos = data.sort((a, b) => a.orden - b.orden);
      //this.modulos = data.filter((a) => a.id_modulo - idmodulo);
    });
  }
  link(item: string) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(item);
  };
  validarInicio() {
    var variable: Date
    this.modulos = this.modulos.sort((a, b) => a.id_modulo - b.id_modulo && a.orden - b.orden);
    for (let f = 0; f < this.modulos.length; f++) {
      for (let i = 0; i < this.modulos[f].capacitaciones.length; i++) {
        if (this.idCapacitacionResultado == this.modulos[f].capacitaciones[i].id_capacitacion_resultado) {
          variable = this.modulos[f].capacitaciones[i].fecha_inicio
          this.calificacion = this.modulos[f].capacitaciones[i].clasificacion
          break
        }
      }
    }
    if (variable === null) {
      this.IniciarCapacitacion(this.idCapacitacionResultado)
    }
  }

  verTest() {
    var variable: boolean
    this.modulos = this.modulos.sort((a, b) => a.id_modulo - b.id_modulo && a.orden - b.orden);
    for (let f = 0; f < this.modulos.length; f++) {
      for (let i = 0; i < this.modulos[f].capacitaciones.length; i++) {
        if (this.idCapacitacionResultado == this.modulos[f].capacitaciones[i].id_capacitacion_resultado) {
          variable = this.modulos[f].capacitaciones[i].concluido
          break
        }
      }
    }
    if (variable == false) {
      this.router.navigate([
        `/recomendaciones/${this.recomendacion.id_recomendacion}/test`,
      ]);
    }
  };

  validarBotonTest() {
    var variable: boolean = false
    this.modulos = this.modulos.sort((a, b) => a.id_modulo - b.id_modulo && a.orden - b.orden);
    for (let f = 0; f < this.modulos.length; f++) {
      for (let i = 0; i < this.modulos[f].capacitaciones.length; i++) {
        if (this.idCapacitacionResultado == this.modulos[f].capacitaciones[i].id_capacitacion_resultado) {
          variable = this.modulos[f].capacitaciones[i].concluido
          break
        }
      }
    }
    return variable
  };


  listarRecomendacion() {
    var request: CapacitacionResultadoRequest = {
      id_capacitacion_resultado: this.idCapacitacionResultado,
    };

    this.repository.listarRecomendacion(request).subscribe({
      next: (data: Recomendacion) => {
        //console.log(data);
        this.recomendacion = data;
      },
      error: (err) => { },
    });
  };
  validarCalificacion(calificacion: number) {
    if (this.calificacion! > 0) {
      this.CalificarCapacitacion();
    }
  };
  CalificarCapacitacion() {
    return this.repository.calificarCapacitacion(this.idCapacitacionResultado).subscribe((data: number) => {
      this.toastService.success(
        'Su calificacion fue registrada correctamente'
      );
    })
  };
  IniciarCapacitacion = (idCapacitacionResultado: number) => {
    return this.repository.iniciarCapacitacion(idCapacitacionResultado).subscribe((data: number) => {
      // this.toastService.success(
      //   'Test de autodiagnóstico finalizado correctamente'
      // );
    })
  };
}
