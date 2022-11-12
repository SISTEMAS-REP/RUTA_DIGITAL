import { APP_INITIALIZER, ErrorHandler, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LoadingComponent } from './components/loading/loading.component';
import { ToastComponent } from './components/toast/toast.component';

import { LoadingInterceptor } from './interceptors/loading.interceptor';
import { TimingInterceptor } from './interceptors/timing.interceptor';
import { GlobalErrorHandler } from './services/global-error.service';
import { AppService, appServiceFactory } from './services/app.service';
import { ModalComponent } from './components/modal/modal.component';
import { ModalTemplateDirective } from './components/modal/modal-template.directive';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
  ],
  declarations: [
    // Custom components
    LoadingComponent,
    ToastComponent,
    ModalComponent,
    ModalTemplateDirective,
  ],
  exports: [
    // Modules
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    // Custom components
    ModalComponent,
    ModalTemplateDirective,
    //LogoutComponent,
    ToastComponent,
    LoadingComponent,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoadingInterceptor,
      multi: true,
    },
    { provide: HTTP_INTERCEPTORS, useClass: TimingInterceptor, multi: true },
    {
      provide: APP_INITIALIZER,
      useFactory: appServiceFactory,
      deps: [AppService],
      multi: true,
    },
    { provide: ErrorHandler, useClass: GlobalErrorHandler },
  ],
})
export class SharedModule {}
