import { Component, OnInit, ViewChild } from '@angular/core';
import { AutodiagnosticoRepository } from '../../autodiagnostico.repository';
import { TestAutodiagnostico } from '../../interfaces/test-autodiagnostico';
import { RespuestaRequest } from '../../interfaces/request/respuesta.request';
import { map, take } from 'rxjs';
import { Respuesta } from '../../interfaces/respuesta';
import { CdkStepper } from '@angular/cdk/stepper';
import { Modulo } from '../../interfaces/modulo';
import { ModuloRequest } from '../../interfaces/request/modulo.request';
import { ToastService } from '../../../shared/services/toast.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-test-autodiagnostico',
  templateUrl: './test-autodiagnostico.component.html',
  styleUrls: [],
})
export class TestAutodiagnosticoComponent implements OnInit {
  @ViewChild('stepper')
  stepper: CdkStepper;

  test?: TestAutodiagnostico;

  constructor(
    private repository: AutodiagnosticoRepository,
    private toastService: ToastService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.listarTestAutodiagnostico();
  }

  validarModulo(idModulo: number) {
    const modulo = this.test.modulos.find((x) => x.id_modulo == idModulo);

    var request: RespuestaRequest = {
      id_evaluacion: this.test?.evaluacion.id_evaluacion,
      id_modulo: modulo.id_modulo,
    };

    return this.repository
      .validarModulo(request)
      .pipe(take(1))
      .subscribe((data) => {
        return data;
      });
  }

  listarTestAutodiagnostico() {
    this.repository
      .listarTestAutodiagnostico()
      .subscribe((data: TestAutodiagnostico) => {
        this.test = data;
      });
  }

  /*onStepperPrevious($event: Modulo) {
    var request: RespuestaRequest = {
      id_evaluacion: this.test?.evaluacion.id_evaluacion,
      id_modulo: $event.id_modulo
    }

    return this.repository
      .validarModulo(request)
      .subscribe((data: boolean) => {
        if (data) {
          this.stepper.previous();
        }
        return data;
      });
  }*/

  onStepperNext($event: Modulo) {
    var request: ModuloRequest = {
      id_modulo: $event.id_modulo,
    };

    return this.repository.validarModulo(request).subscribe((data: boolean) => {
      console.log('onStepperNext', data)
      if (data) {
        this.stepper.next();
      }
      return data;
    });
  }

  onStepperFinish() {
    return this.repository.procesarEvaluacion().subscribe((data: boolean) => {
      if (data) {
        this.toastService.success('Test de autodiagnóstico finalizado correctamente');
        this.router.navigate(['/autodiagnostico/resultado']);
      }
      return data;
    });
  }
}
