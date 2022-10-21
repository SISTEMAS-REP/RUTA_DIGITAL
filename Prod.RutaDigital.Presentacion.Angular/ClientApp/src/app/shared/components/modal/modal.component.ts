import { Component } from '@angular/core';
import { ModalOptions } from '../../interfaces/modal-options';
import { ModalStateService } from '../../services/modal-state.service';

/**
 * The component displayed in the confirmation modal opened by the ModalService.
 */
@Component({
  selector: 'app-modal-component',
  styleUrls: ['modal.component.css'],
  templateUrl: './modal.component.html',
})
export class ModalComponent {
  options: ModalOptions;

  constructor(private state: ModalStateService) {
    this.options = state.options;
  }

  yes() {
    this.state.modal.close('confirmed');
  }

  no() {
    this.state.modal.dismiss('not confirmed');
  }
}
