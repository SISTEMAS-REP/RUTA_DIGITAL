import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Modulo } from 'src/app/autodiagnostico/interfaces/modulo';
import { RecomendacionesRepository } from '../../repositories/recomendaciones.repository';

@Component({
  selector: 'app-recomendaciones',
  templateUrl: './recomendaciones.component.html',
  styleUrls: [],
})
export class RecomendacionesComponent implements OnInit {
  idModulo?: number;
  modulos: Modulo[];

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
      this.modulos = data.sort((a, b) => a.id_modulo - b.id_modulo);
    });
  }

  verRecomendacion = (idCapacitacionResultado: number) => {
    console.log('recomendacion', idCapacitacionResultado);
    this.router.navigate([
      `/recomendaciones/detalle/${idCapacitacionResultado}`,
    ]);
  };

  moduloVisible(): number {
    const id = this.idModulo ?? this.modulos[0].id_modulo;
    console.log('moduloVisible-id', id);
    return id;
  }
}
