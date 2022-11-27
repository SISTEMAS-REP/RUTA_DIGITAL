import { Component, OnInit } from '@angular/core';
import { RecomendacionesRepository } from 'src/app/recomendaciones/repositories/recomendaciones.repository';
import { TestAvance } from 'src/app/recomendaciones/interfaces/test-avance';
import { ActivatedRoute } from '@angular/router';
import { RecomendacionRequest } from '../../interfaces/request/recomendacion.request';
import { CapacitacionDetRequest } from '../../interfaces/request/capacitacion-det.request';
import { TestAvanceRequest } from '../../interfaces/request/test-avance.request';
@Component({
  selector: 'app-test-avance',
  templateUrl: './test-avance.component.html',
  styleUrls: [],
})
export class TestAvanceComponent implements OnInit {
  idRecomendacion: number;
  test: TestAvance;

  request: TestAvanceRequest;

  constructor(
    private repository: RecomendacionesRepository,
    private activatedRoute: ActivatedRoute
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
      id_recomendacion: this.idRecomendacion
    };

    this.repository.listarTestAvance(request).subscribe({
      next: (data: TestAvance) => {
        this.test = data;
      },
    });
  }

  toogle($event: CapacitacionDetRequest) {
    console.log('TestAvanceComponent/toogle', $event);
  }

  enviarTest() {
    return this.repository.procesarAvance(this.request).subscribe((data: number) => {
      console.log('enviarTest', data);
    });
  }
}