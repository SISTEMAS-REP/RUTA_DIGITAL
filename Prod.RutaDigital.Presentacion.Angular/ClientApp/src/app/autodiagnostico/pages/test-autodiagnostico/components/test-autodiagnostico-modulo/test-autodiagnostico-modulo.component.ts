import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Modulo } from 'src/app/autodiagnostico/interfaces/modulo';

@Component({
  selector: 'app-test-autodiagnostico-modulo',
  templateUrl: './test-autodiagnostico-modulo.component.html',
  styleUrls: [],
})
export class TestAutodiagnosticoModuloComponent implements OnInit {
  //@Output() onStepperPrevious: EventEmitter<any> = new EventEmitter();
  @Output() onStepperNext: EventEmitter<any> = new EventEmitter();
  //@Output() onStepperFinish: EventEmitter<any> = new EventEmitter();

  @Input() modulo: Modulo;

  @Input() first: boolean;
  @Input() last: boolean;

  constructor() {}

  ngOnInit(): void {}

  /*onPrevious() {
    this.onStepperNext.emit(this.modulo);
  }*/

  onNext() {
    this.onStepperNext.emit(this.modulo);
  }

  /*onFinish() {
    this.onStepperFinish.emit();
  }*/
}
