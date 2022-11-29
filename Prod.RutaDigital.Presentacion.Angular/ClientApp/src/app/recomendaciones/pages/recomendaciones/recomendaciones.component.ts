import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Modulo } from 'src/app/autodiagnostico/interfaces/modulo';
import { CapacitacionResultadoRequest } from 'src/app/recomendaciones/interfaces/request/capacitacion-resultado.request';
import { RecomendacionesRepository } from '../../repositories/recomendaciones.repository';
import { Recomendacion } from '../../interfaces/recomendacion';
import { ValidacionRecomendaciones } from '../../interfaces/validacion-recomendaciones';

@Component({
  selector: 'app-recomendaciones',
  templateUrl: './recomendaciones.component.html',
  styleUrls: [],
})
export class RecomendacionesComponent implements OnInit {
  idModulo?: number;
  IdCapacitacion_: number;
  IdNivelMadurez_: number;
  modulos: Modulo[];
  validar_item: ValidacionRecomendaciones[] = [];
  datos_capacitacion: Recomendacion;
  IdModulo_: number;
  Concluido: boolean;
  bloqueado: boolean;
  estado: boolean;
  visible: boolean;
  constructor(
    private repository: RecomendacionesRepository,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {
    this.activatedRoute.params.subscribe((params) => {
      this.idModulo = params['idModulo'];
    });
  }

  ngOnInit(): void {
    this.listarCapacitaciones();

  }

  listarCapacitaciones() {
    this.repository.listarCapacitaciones().subscribe((data: Modulo[]) => {
      this.modulos = data.sort((a, b) => a.orden - b.orden);
      this.validarModulos();
    });
  }


  verRecomendacion = (idCapacitacionResultado: number, concluido: boolean) => {

    if (concluido == true) {
      this.router.navigate([
        `/recomendaciones/detalle/${idCapacitacionResultado}`,
      ]);
    }
    else {
      var respuesta: boolean

      for (let f = 0; f < this.validar_item.length; f++) {
        if (this.validar_item[f].id_Capacitacion === idCapacitacionResultado) {
          respuesta = this.validar_item[f].estado
          break
        }
      }

      if (respuesta == true) {
        this.router.navigate([
          `/recomendaciones/detalle/${idCapacitacionResultado}`,
        ]);
      }

    }
  };
  moduloVisible(): number {
    const id = this.idModulo ?? this.modulos[0].id_modulo;
    console.log('moduloVisible-id', id);
    return id;
  };
  moduloActivo = (idCapacitacionResultado: number) => {
    var respuesta: boolean

    for (let f = 0; f < this.validar_item.length; f++) {
      if (this.validar_item[f].id_Capacitacion === idCapacitacionResultado) {
        respuesta = this.validar_item[f].visible
        break
      }
    }

    if (respuesta == true) {
      return true
    }
    else {
      return false
    }
  };

  validarModulos() {
    this.IdModulo_ = 0
    this.IdNivelMadurez_ = 0
    this.IdCapacitacion_ = 0
    this.bloqueado = false
    this.Concluido = false
    this.estado = false
    this.modulos = this.modulos.sort((a, b) => a.id_modulo - b.id_modulo && a.orden - b.orden);
    for (let f = 0; f < this.modulos.length; f++) {
      for (let i = 0; i < this.modulos[f].capacitaciones.sort((a, b) => a.id_modulo - b.id_modulo && a.id_nivel_madurez - b.id_nivel_madurez && a.orden_recomendacion - b.orden_recomendacion).length; i++) {
        if (this.IdModulo_ == 0) {
          if (this.modulos[f].capacitaciones[i].concluido == false) {
            this.IdCapacitacion_ = this.modulos[f].capacitaciones[i].id_capacitacion_resultado
            this.Concluido = false
            this.bloqueado = true
            this.IdNivelMadurez_ = this.modulos[f].capacitaciones[i].id_nivel_madurez
            this.IdModulo_ = this.modulos[f].capacitaciones[i].id_modulo
            this.estado = true
            this.visible = true
          }
          else {
            this.IdCapacitacion_ = this.modulos[f].capacitaciones[i].id_capacitacion_resultado
            this.Concluido = true
            this.bloqueado = false
            this.IdNivelMadurez_ = this.modulos[f].capacitaciones[i].id_nivel_madurez
            this.IdModulo_ = this.modulos[f].capacitaciones[i].id_modulo
            this.estado = true
            this.visible = true
          }
        }
        else if (this.modulos[f].capacitaciones[i].id_nivel_madurez == this.IdNivelMadurez_ && this.modulos[f].capacitaciones[i].id_modulo == this.IdModulo_) {
          if (this.visible == false) {
            this.visible = false
          }
          else {
            this.visible = true
          }
          if (this.bloqueado == true) {
            this.IdCapacitacion_ = this.modulos[f].capacitaciones[i].id_capacitacion_resultado
            this.Concluido = this.modulos[f].capacitaciones[i].concluido
            this.bloqueado = true
            this.IdNivelMadurez_ = this.modulos[f].capacitaciones[i].id_nivel_madurez
            this.IdModulo_ = this.modulos[f].capacitaciones[i].id_modulo
            this.estado = false
          }
          else {
            if (this.modulos[f].capacitaciones[i].concluido == false) {
              this.IdCapacitacion_ = this.modulos[f].capacitaciones[i].id_capacitacion_resultado
              this.Concluido = this.modulos[f].capacitaciones[i].concluido
              this.bloqueado = true
              this.IdNivelMadurez_ = this.modulos[f].capacitaciones[i].id_nivel_madurez
              this.IdModulo_ = this.modulos[f].capacitaciones[i].id_modulo
              this.estado = true
            }
            else {
              this.IdCapacitacion_ = this.modulos[f].capacitaciones[i].id_capacitacion_resultado
              this.Concluido = this.modulos[f].capacitaciones[i].concluido
              this.bloqueado = false
              this.IdNivelMadurez_ = this.modulos[f].capacitaciones[i].id_nivel_madurez
              this.IdModulo_ = this.modulos[f].capacitaciones[i].id_modulo
              this.estado = true

            }
          }
        }
        else if (this.modulos[f].capacitaciones[i].id_nivel_madurez != this.IdNivelMadurez_ && this.modulos[f].capacitaciones[i].id_modulo == this.IdModulo_) {
          if (this.bloqueado == true) {
            this.IdCapacitacion_ = this.modulos[f].capacitaciones[i].id_capacitacion_resultado
            this.Concluido = this.modulos[f].capacitaciones[i].concluido
            this.bloqueado = true
            this.IdNivelMadurez_ = this.modulos[f].capacitaciones[i].id_nivel_madurez
            this.IdModulo_ = this.modulos[f].capacitaciones[i].id_modulo
            this.estado = false
            this.visible = false
          }
          else {

            if (this.modulos[f].capacitaciones[i].concluido == false) {
              this.IdCapacitacion_ = this.modulos[f].capacitaciones[i].id_capacitacion_resultado
              this.Concluido = this.modulos[f].capacitaciones[i].concluido
              this.bloqueado = true
              this.IdNivelMadurez_ = this.modulos[f].capacitaciones[i].id_nivel_madurez
              this.IdModulo_ = this.modulos[f].capacitaciones[i].id_modulo
              this.estado = true
              if (this.visible == false) {
                this.visible = false
              } else {
                this.visible = true
              }

            }
            else {
              this.IdCapacitacion_ = this.modulos[f].capacitaciones[i].id_capacitacion_resultado
              this.Concluido = this.modulos[f].capacitaciones[i].concluido
              this.bloqueado = false
              this.IdNivelMadurez_ = this.modulos[f].capacitaciones[i].id_nivel_madurez
              this.IdModulo_ = this.modulos[f].capacitaciones[i].id_modulo
              this.estado = true
              if (this.visible == false) {
                this.visible = false
              } else {
                this.visible = true
              }
            }

          }
        }
        else if (this.modulos[f].capacitaciones[i].id_nivel_madurez != this.IdNivelMadurez_ && this.modulos[f].capacitaciones[i].id_modulo != this.IdModulo_) {
          if (this.modulos[f].capacitaciones[i].concluido == false) {
            this.IdCapacitacion_ = this.modulos[f].capacitaciones[i].id_capacitacion_resultado
            this.Concluido = this.modulos[f].capacitaciones[i].concluido
            this.bloqueado = true
            this.IdNivelMadurez_ = this.modulos[f].capacitaciones[i].id_nivel_madurez
            this.IdModulo_ = this.modulos[f].capacitaciones[i].id_modulo
            this.estado = true
            this.visible = true
          }
          else {
            this.IdCapacitacion_ = this.modulos[f].capacitaciones[i].id_capacitacion_resultado
            this.Concluido = this.modulos[f].capacitaciones[i].concluido
            this.bloqueado = false
            this.IdNivelMadurez_ = this.modulos[f].capacitaciones[i].id_nivel_madurez
            this.IdModulo_ = this.modulos[f].capacitaciones[i].id_modulo
            this.estado = true
            this.visible = true
          }
        }
        else
          if (this.Concluido == true) {
            this.IdCapacitacion_ = this.modulos[f].capacitaciones[i].id_capacitacion_resultado
            this.Concluido = this.modulos[f].capacitaciones[i].concluido
            this.bloqueado = true
            this.IdNivelMadurez_ = this.modulos[f].capacitaciones[i].id_nivel_madurez
            this.IdModulo_ = this.modulos[f].capacitaciones[i].id_modulo
            this.estado = true
            this.visible = true
          }
          else {
            this.IdCapacitacion_ = this.modulos[f].capacitaciones[i].id_capacitacion_resultado
            this.Concluido = this.modulos[f].capacitaciones[i].concluido
            this.bloqueado = false
            this.IdNivelMadurez_ = this.modulos[f].capacitaciones[i].id_nivel_madurez
            this.IdModulo_ = this.modulos[f].capacitaciones[i].id_modulo
            this.estado = true
            this.visible = true
          }


        this.validar_item.push({ id_Capacitacion: this.IdCapacitacion_, concluido: this.Concluido, id_nivel_madurez: this.IdNivelMadurez_, id_modulo: this.IdModulo_, estado: this.estado, visible: this.visible })
      }
    }
  };
}




