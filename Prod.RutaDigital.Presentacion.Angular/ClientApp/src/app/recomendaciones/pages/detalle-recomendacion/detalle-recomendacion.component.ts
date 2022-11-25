import { Component, OnInit } from '@angular/core';
import { RecomendacionesRepository } from '../../repositories/recomendaciones.repository';
import { ActivatedRoute } from '@angular/router';
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

  recomendacion: Recomendacion;

  constructor(
    private repository: RecomendacionesRepository,
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

  listarRecomendacion = () => {
    var request: CapacitacionResultadoRequest = {
      id_capacitacion_resultado: this.idCapacitacionResultado,
    };

    this.repository.listarRecomendacion(request).subscribe({
      next: (data: Recomendacion) => {
        this.recomendacion = data;
      },
      error: (err) => {},
    });
  };
}
