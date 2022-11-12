import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ApplicationPaths } from './authorization.constants';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { CookieInterceptor } from './interceptors/cookie.interceptor';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

@NgModule({
  declarations: [LoginComponent, LogoutComponent],
  imports: [
    CommonModule,

    RouterModule.forChild([
      { path: ApplicationPaths.LoginPerson, component: LoginComponent },
      { path: ApplicationPaths.LoginCompany, component: LoginComponent },

      { path: ApplicationPaths.Register, component: LoginComponent },
      { path: ApplicationPaths.Profile, component: LoginComponent },
      { path: ApplicationPaths.LoginFailed, component: LoginComponent },
      { path: ApplicationPaths.LoginCallback, component: LoginComponent },

      { path: ApplicationPaths.LogOut, component: LogoutComponent },
      { path: ApplicationPaths.LoggedOut, component: LogoutComponent },
      { path: ApplicationPaths.LogOutCallback, component: LogoutComponent },
    ]),
  ],
  exports: [LoginComponent, LogoutComponent],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CookieInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },]
})
export class AuthorizationModule {}
