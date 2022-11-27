import { Component, OnInit } from '@angular/core';
import { ResultadoTestAvance } from 'src/app/recomendaciones/interfaces/resultado-test-avance';
import { TestAvanceRepository } from 'src/app/recomendaciones/repositories/test-avance.repository';
import { ExtranetUser } from '../../../shared/interfaces/extranet-user';
import { CodGenero } from 'src/app/shared/enums/cod-genero.enum';

@Component({
  selector: 'app-resultado-autodiagnostico',
  templateUrl: './resultado-test-avance.component.html',
  styleUrls: [],
})
export class ResultadoAutodiagnosticoComponent implements OnInit {
  usuario: ExtranetUser;
  resultadoAutodiagnostico: ResultadoTestAvance;

  constructor(private repository: TestAvanceRepository) {
    this.usuario = this.repository.obtenerUsuario();
  }

  ngOnInit(): void {
    // this.repository
    //   .listarResultadoAutodiagnostico()
    //   .subscribe((data: ResultadoTestAvance) => {
    //     this.resultadoAutodiagnostico = data;
    //   });
  }

  mostrarTituloPorGenero(codGenero: string) {
    var articulo = CodGenero.MASCULINO.toString() == codGenero ? 'El' : 'La';
    var sustantivo =
      CodGenero.MASCULINO.toString() == codGenero
        ? 'Emprendedor'
        : 'Emprendedora';

    return `${articulo} ${sustantivo}`;
  }
}
