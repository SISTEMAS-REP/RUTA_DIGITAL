import { BrowserModule } from '@angular/platform-browser';
import { LOCALE_ID, NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { SharedModule } from './shared/shared.module';
import { FooterComponent } from './components/footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { ProduceMasBarComponent } from './components/produce-mas-bar/produce-mas-bar.component';
import { HeaderComponent } from './components/header/header.component';
import { CommonModule, registerLocaleData } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import LocalES from '@angular/common/locales/es';
import { AuthorizationModule } from './authorization/authorization.module';
import { FormsModule } from '@angular/forms';
registerLocaleData(LocalES, 'es');

@NgModule({
  declarations: [
    AppComponent,

    HeaderComponent,
    ProduceMasBarComponent,
    NavMenuComponent,
    FooterComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    RouterModule,
    AppRoutingModule,
    ToastrModule.forRoot({
      preventDuplicates: false,
    }),
    AuthorizationModule,
    SharedModule,
    FormsModule
  ],
  bootstrap: [AppComponent],
  providers: [{ provide: LOCALE_ID, useValue: 'es' }],
})
export class AppModule {}
