import { APP_INITIALIZER, ErrorHandler, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LoadingComponent } from './components/loading/loading.component';

import { LoadingInterceptor } from './interceptors/loading.interceptor';
import { TimingInterceptor } from './interceptors/timing.interceptor';
import { GlobalErrorHandler } from './services/global-error.service';
import { AppService, appServiceFactory } from './services/app.service';
import { NivelModuloComponent } from './components/nivel-modulo/nivel-modulo.component';
import { NivelMadurezComponent } from './components/nivel-madurez/nivel-madurez.component';

@NgModule({
  imports: [CommonModule, HttpClientModule, FormsModule, ReactiveFormsModule],
  declarations: [
    // Custom components
    LoadingComponent,
    NivelModuloComponent,
    NivelMadurezComponent
  ],
  exports: [
    // Modules
    //CommonModule,
    //FormsModule,
    //ReactiveFormsModule,
    LoadingComponent,
    NivelModuloComponent,
    NivelMadurezComponent
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
