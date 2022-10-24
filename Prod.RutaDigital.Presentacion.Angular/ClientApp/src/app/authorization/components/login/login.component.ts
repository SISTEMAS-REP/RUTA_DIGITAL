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
  public loginUnicoApiPath: string;

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
    this.loginUnicoApiPath =
      this.appService.appData.content['loginUnicoApiPath'];
  }

  async ngOnInit() {
    var snapshot = this.activatedRoute.snapshot;
    const action = this.activatedRoute.snapshot.url[1];
    switch (action.path) {
      case LoginActions.Login:
        await this.login(this.getReturnUrl());
        //this.redirectToLogin();
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

  private async login(returnUrl: string): Promise<void> {
    const state: INavigationState = { returnUrl };
    const result = await this.authorizeService.signIn(state);
    this.message.next(undefined);
    switch (result.status) {
      case AuthenticationResultStatus.Redirect:
        await this.redirectToLogin(result.state);
        break;
      case AuthenticationResultStatus.Success:
        await this.navigateToReturnUrl(returnUrl);
        break;
      case AuthenticationResultStatus.Fail:
        await this.router.navigate(ApplicationPaths.LoginFailedPathComponents, {
          queryParams: { [QueryParameterNames.Message]: result.message },
        });
        break;
      default:
        throw new Error(`Invalid status result ${(result as any).status}.`);
    }
  }

  private async processLoginCallback(): Promise<void> {
    const url = window.location.href;
    const result = await this.authorizeService.completeSignIn(url);
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

  private redirectToLogin(state: INavigationState): any {
    const redirectUrl = `${this.loginUnicoWebPath}${
      ApplicationPaths.IdentityLogin
    }?applicationId=${this.applicationId}&${ReturnUrlType}=${encodeURI(
      this.url +
        ApplicationPaths.LoginCallback +
        '?' +
        ReturnUrlType +
        '=' +
        state.returnUrl
    )}`;
    console.log('redirectToLogin', redirectUrl);
    this.redirectToApiAuthorizationPath(redirectUrl);
  }

  private redirectToRegister(): any {
    const redirectUrl = `${this.loginUnicoWebPath}${
      ApplicationPaths.IdentityRegister
    }?applicationId=${this.applicationId}&${ReturnUrlType}=${encodeURI(
      this.url
    )}`;
    console.log('redirectToRegister', redirectUrl);
    this.redirectToApiAuthorizationPath(redirectUrl);
  }

  private redirectToProfile(): void {
    const redirectUrl = `${this.loginUnicoWebPath}${
      ApplicationPaths.IdentityManage
    }?applicationId=${this.applicationId}&${ReturnUrlType}=${encodeURI(
      this.url
    )}`;
    console.log('redirectToProfile', redirectUrl);
    this.redirectToApiAuthorizationPath(redirectUrl);
  }

  private async navigateToReturnUrl(returnUrl: string) {
    // It's important that we do a replace here so that we remove the callback uri with the
    // fragment containing the tokens from the browser history.
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
    // It's important that we do a replace here so that when the user hits the back arrow on the
    // browser they get sent back to where it was on the app instead of to an endpoint on this
    // component.
    window.location.replace(apiAuthorizationPath);
  }
}
