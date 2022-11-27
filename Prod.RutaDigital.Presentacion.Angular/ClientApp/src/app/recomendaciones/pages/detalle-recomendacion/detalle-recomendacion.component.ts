import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { RecomendacionesRepository } from '../../repositories/recomendaciones.repository';
import { ActivatedRoute, Router } from '@angular/router';
import { CapacitacionResultadoRequest } from '../../interfaces/request/capacitacion-resultado.request';
import { Recomendacion } from '../../interfaces/recomendacion';


@Component({
  selector: 'app-detalle-recomendacion',
  templateUrl: './detalle-recomendacion.component.html',
  styleUrls: [],
})
export class DetalleRecomendacionComponent implements OnInit {
  idCapacitacionResultado: number;
  recomendacion?: Recomendacion;
  sanitizedURL: DomSanitizer;
  
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

  link(item: string) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(item);
  }

  verTest() {
    this.router.navigate([
      `/recomendaciones/${this.recomendacion.id_recomendacion}/test`,
    ]);
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
}
