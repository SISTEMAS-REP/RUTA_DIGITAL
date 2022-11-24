import { Component, OnInit } from '@angular/core';
import { ResultadoAutodiagnostico } from '../../interfaces/resultado-autodiagnostico';
import { AutodiagnosticoRepository } from '../../autodiagnostico.repository';
import { ExtranetUser } from '../../../shared/interfaces/extranet-user';
import { CodGenero } from 'src/app/shared/enums/cod-genero.enum';

@Component({
  selector: 'app-resultado-autodiagnostico',
  templateUrl: './resultado-autodiagnostico.component.html',
  styleUrls: [],
})
export class ResultadoAutodiagnosticoComponent implements OnInit {
  usuario: ExtranetUser;
  resultadoAutodiagnostico: ResultadoAutodiagnostico;

  constructor(private repository: AutodiagnosticoRepository) {
    this.usuario = this.repository.obtenerUsuario();
  }

  ngOnInit(): void {
    this.repository
      .listarResultadoAutodiagnostico()
      .subscribe((data: ResultadoAutodiagnostico) => {
        this.resultadoAutodiagnostico = data;
      });
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
