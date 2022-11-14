import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { INavigationState } from '../../interfaces/navigation-state';
import { AppService } from 'src/app/shared/services/app.service';
import {
  AuthenticationResultStatus,
  AuthorizeService,
} from '../../authorize.service';
import {
  ApplicationIdType,
  ApplicationPaths,
  LoginActions,
  QueryParameterNames,
  ReturnUrlType,
} from '../../authorization.constants';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: [],
})
export class LoginComponent implements OnInit {
  private url = window.location.href;

  public message = new BehaviorSubject<string>(null);

  public applicationId: string;
  public loginUnicoWebPath: string;

  constructor(
    @Inject('BASE_URL') private BASE_URL: string,
    private appService: AppService,
    private authorizeService: AuthorizeService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.applicationId = this.appService.appData.content['applicationId'];
    this.loginUnicoWebPath =
      this.appService.appData.content['loginUnicoWebPath'];
  }

  async ngOnInit() {
    const action = this.activatedRoute.snapshot.url[1];
    switch (action.path) {
      case LoginActions.LoginPerson:
        await this.redirectToLogin(ApplicationPaths.IdentityLoginPerson);
        break;
      case LoginActions.LoginCompany:
        await this.redirectToLogin(ApplicationPaths.IdentityLoginCompany);
        break;
      case LoginActions.LoginCallback:
        await this.processLoginCallback();
        break;
      case LoginActions.LoginFailed:
        const message = this.activatedRoute.snapshot.queryParamMap.get(
          QueryParameterNames.Message
        );
        this.message.next(message);
        break;
      case LoginActions.Profile:
        this.redirectToProfile();
        break;
      case LoginActions.Register:
        this.redirectToRegister();
        break;
      default:
        throw new Error(`Invalid action '${action}'`);
    }
  }

  private async processLoginCallback(): Promise<void> {
    const result = await this.authorizeService.completeSignIn();
    switch (result.status) {
      case AuthenticationResultStatus.Redirect:
        // There should not be any redirects as completeSignIn never redirects.
        throw new Error('Should not redirect.');
      case AuthenticationResultStatus.Success:
        await this.navigateToReturnUrl(this.getReturnUrl());
        break;
      case AuthenticationResultStatus.Fail:
        this.message.next(result.message);
        break;
    }
  }

  private redirectToLogin(applicationPath: string): any {
    const redirectUrl =
      `${this.loginUnicoWebPath}${applicationPath}` +
      `?${ApplicationIdType}=${this.applicationId}` +
      `&${ReturnUrlType}=${this.setReturnLogin()}`;

    this.redirectToApiAuthorizationPath(redirectUrl);
  }

  private setReturnLogin() {
    return encodeURI(this.BASE_URL + ApplicationPaths.LoginCallback);
  }

  private redirectToRegister() {
    const redirectUrl =
      `${this.loginUnicoWebPath}${ApplicationPaths.IdentityRegister}` +
      `?${ApplicationIdType}=${this.applicationId}` +
      `&${ReturnUrlType}=${encodeURI(this.BASE_URL)}`;

    this.redirectToApiAuthorizationPath(redirectUrl);
  }

  private redirectToProfile() {
    const redirectUrl =
      `${this.loginUnicoWebPath}${ApplicationPaths.IdentityProfile}` +
      `?${ApplicationIdType}=${this.applicationId}` +
      `&${ReturnUrlType}=${encodeURI(this.BASE_URL)}`;

    this.redirectToApiAuthorizationPath(redirectUrl);
  }

  private async navigateToReturnUrl(returnUrl: string) {
    await this.router.navigateByUrl(returnUrl, {
      replaceUrl: true,
    });
  }

  private getReturnUrl(state?: INavigationState): string {
    const fromQuery = (
      this.activatedRoute.snapshot.queryParams as INavigationState
    ).returnUrl;
    // If the url is comming from the query string, check that is either
    // a relative url or an absolute url
    if (
      fromQuery &&
      !(
        fromQuery.startsWith(`${window.location.origin}/`) ||
        /\/[^\/].*/.test(fromQuery)
      )
    ) {
      // This is an extra check to prevent open redirects.
      throw new Error(
        'Invalid return url. The return url needs to have the same origin as the current page.'
      );
    }
    return (
      (state && state.returnUrl) ||
      fromQuery ||
      ApplicationPaths.DefaultLoginRedirectPath
    );
  }

  private redirectToApiAuthorizationPath(apiAuthorizationPath: string) {
    console.log('redirectToApiAuthorizationPath', apiAuthorizationPath);
    // It's important that we do a replace here so that when the user hits the back arrow on the
    // browser they get sent back to where it was on the app instead of to an endpoint on this
    // component.
    window.location.replace(apiAuthorizationPath);
  }
}
