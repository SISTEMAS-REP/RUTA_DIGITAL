import { Component, OnInit, ViewChild } from '@angular/core';
import { AutodiagnosticoRepository } from '../../autodiagnostico.repository';
import { TestAutodiagnostico } from '../../interfaces/test-autodiagnostico';
import { RespuestaRequest } from '../../interfaces/request/respuesta.request';
import { map, take } from 'rxjs';
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

  currentStep: number;

  test?: TestAutodiagnostico;

  constructor(
    private repository: AutodiagnosticoRepository,
    private toastService: ToastService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.listarTestAutodiagnostico();
  }

  validarModulo(idModulo: number, index) {
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
        this.seleccionarModuloInicial();
      });
  }

  seleccionarModuloInicial() {
    var id_modulo = this.test.evaluacion.modulo_activo;
    var id_pregunta = this.test.evaluacion.pregunta_activa;
    var index = this.test.modulos.findIndex((f) => f.id_modulo == id_modulo);

    setTimeout(() => {
      console.log('start', this.stepper);
      this.stepper.steps.map((s, i) => {
        if (i < index) {
          s.completed = true;
          this.test.modulos[i].completado = true;
        }
      });
      this.stepper.selectedIndex = index;

      this.scrollOn(`pregunta-${id_pregunta}`);
    });
  }

  onStepperPrevious($event: Modulo, index: number) {
    this.stepper.previous();
    this.scrollOn('title');
  }

  onStepperNext($event: Modulo, index: number, last: boolean) {
    console.log('$event', $event);
    var request: ModuloRequest = {
      id_modulo: $event.id_modulo,
    };

    this.repository.validarModulo(request).subscribe((data: boolean) => {
      this.test.modulos[index].completado = data ?? false;
      this.stepper.steps.get(index).completed = data ?? false;

      if (data) {
        this.stepper.next();
        this.scrollOn('title');

        if (last) {
          this.onStepperFinish();
        }
      }
    });
  }

  scrollOn(classElement: string) {
    const element = document.querySelector(`.${classElement}`);
    setTimeout(() => {
      element.scrollIntoView({
        behavior: 'smooth',
        block: 'start',
        inline: 'nearest',
      });
      console.log('scrollIntoView');
    }, 250);
  }

  onStepperFinish() {
    this.repository.procesarEvaluacion().subscribe((data: boolean) => {
      if (data) {
        this.toastService.success(
          'Test de autodiagnóstico finalizado correctamente'
        );
        this.router.navigate(['/autodiagnostico/resultado']);
      }
      return data;
    });
  }
}
