import { Component, OnInit } from '@angular/core';
import { ResultadoAutodiagnosticoHistorico } from '../../interfaces/resultado-autodiagnostico-historico';
import { AutodiagnosticoHistoricoRepository } from '../../autodiagnostico-historico.repository';
import { ExtranetUser } from '../../../shared/interfaces/extranet-user';
import { CodGenero } from 'src/app/shared/enums/cod-genero.enum';

@Component({
  selector: 'app-resultado-autodiagnostico-historico',
  templateUrl: './resultado-autodiagnostico-historico.component.html',
  styleUrls: [],
})
export class ResultadoAutodiagnosticoHistoricoComponent implements OnInit {
  usuario: ExtranetUser;
  resultadoAutodiagnosticoHistorico: ResultadoAutodiagnosticoHistorico;

  constructor(private repository: AutodiagnosticoHistoricoRepository) {
    this.usuario = this.repository.obtenerUsuario();
  }

  ngOnInit(): void {
    this.repository
      .listarResultadoAutodiagnosticoHistorico()
      .subscribe((data: ResultadoAutodiagnosticoHistorico) => {
        this.resultadoAutodiagnosticoHistorico = data;
      });
  }

  mostrarTituloPorGenero(codGenero?: string) {
    if (!codGenero) {
      return 'El/a Emprendedor/a';
    }

    var articulo = CodGenero.MASCULINO.toString() == codGenero ? 'El' : 'La';
    var sustantivo =
      CodGenero.MASCULINO.toString() == codGenero
        ? 'Emprendedor'
        : 'Emprendedora';

    return `${articulo} ${sustantivo}`;
  }
}
