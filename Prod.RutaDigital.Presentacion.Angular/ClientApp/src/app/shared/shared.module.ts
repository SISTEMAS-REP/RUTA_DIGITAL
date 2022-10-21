import { APP_INITIALIZER, ErrorHandler, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import {
  NgbDateAdapter,
  NgbDateParserFormatter,
  NgbModule,
} from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LoadingComponent } from './components/loading/loading.component';
import { ToastComponent } from './components/toast/toast.component';

import { LoadingInterceptor } from './interceptors/loading.interceptor';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { TimingInterceptor } from './interceptors/timing.interceptor';
import { GlobalErrorHandler } from './services/global-error.service';
import { CookieInterceptor } from './interceptors/cookie.interceptor';
import { AppService, appServiceFactory } from './services/app.service';
import { LoginComponent } from './components/login/login.component';
import { TranslatePipe } from './pipes/translate.pipe';
import { LogoutComponent } from './components/logout/logout.component';
import { RouterModule } from '@angular/router';
import { ApplicationPaths } from './constants/auth.constants';
import { CustomDateFormatter } from './services/custom-date-formatter.service';
import { CustomNgbDateNativeUTCAdapter } from './services/custom-date-adapter.service';
import { ModalComponent } from './components/modal/modal.component';
import { ModalTemplateDirective } from './components/modal/modal-template.directive';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    RouterModule.forChild([
      { path: ApplicationPaths.Register, component: LoginComponent },
      { path: ApplicationPaths.Profile, component: LoginComponent },
      { path: ApplicationPaths.Login, component: LoginComponent },
      { path: ApplicationPaths.LoginFailed, component: LoginComponent },
      { path: ApplicationPaths.LoginCallback, component: LoginComponent },
      { path: ApplicationPaths.LogOut, component: LogoutComponent },
      { path: ApplicationPaths.LoggedOut, component: LogoutComponent },
      { path: ApplicationPaths.LogOutCallback, component: LogoutComponent },
    ]),
  ],
  declarations: [
    // pipes
    TranslatePipe,
    // Custom components
    LoadingComponent,
    ToastComponent,
    LoginComponent,
    LogoutComponent,
    ModalComponent,
    ModalTemplateDirective,
  ],
  exports: [
    // Modules
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    // pipes
    TranslatePipe,
    // Custom components
    LoginComponent,
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
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CookieInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
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
    { provide: NgbDateParserFormatter, useClass: CustomDateFormatter },
    { provide: NgbDateAdapter, useClass: CustomNgbDateNativeUTCAdapter },
  ],
})
export class SharedModule {}
