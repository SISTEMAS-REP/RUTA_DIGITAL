import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject, take } from 'rxjs';
import { AppService } from 'src/app/shared/services/app.service';
import {
  ApplicationIdType,
  ApplicationPaths,
  LogoutActions,
  ReturnUrlType,
} from '../../authorization.constants';
import {
  AuthenticationResultStatus,
  AuthorizeService,
} from '../../authorize.service';
import { INavigationState } from '../../interfaces/navigation-state';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: [],
})
export class LogoutComponent implements OnInit {
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
      case LogoutActions.Logout:
        //if (!!window.history.state.local) {
          await this.logout(this.url, this.applicationId);
        /*} else {
          // This prevents regular links to <app>/authentication/logout from triggering a logout
          this.message.next(
            'The logout was not initiated from within the page.'
          );
        }*/
        break;
      case LogoutActions.LogoutCallback:
        await this.processLogoutCallback();
        break;
      case LogoutActions.LoggedOut:
        this.message.next('You have successfully logged out!');
        break;
      default:
        throw new Error(`Invalid action '${action}'`);
    }
  }

  private async logout(
    returnUrl: string,
    applicationId: string
  ): Promise<void> {
    const state: INavigationState = { returnUrl, applicationId };
    const isAuthenticated = await this.authorizeService
      .isAuthenticated()
      .pipe(take(1))
      .toPromise();
    if (isAuthenticated) {
      await this.redirectToLogout(state);
    } else {
      this.message.next('You have successfully logged out!');
    }
  }

  private async processLogoutCallback(): Promise<void> {
    const result = await this.authorizeService.completeSignOut();
    switch (result.status) {
      case AuthenticationResultStatus.Redirect:
        throw new Error('Should not redirect.');
      case AuthenticationResultStatus.Success:
        await this.navigateToReturnUrl(this.getReturnUrl());
        //await this.navigateToReturnUrl(this.getReturnUrl(result.state));
        break;
      case AuthenticationResultStatus.Fail:
        this.message.next(result.message);
        break;
      default:
        throw new Error('Invalid authentication result status.');
    }
  }

  redirectToLogout(state: INavigationState) {
    const redirectUrl =
      `${this.loginUnicoWebPath}${ApplicationPaths.IdentityLogout}` +
      `?${ApplicationIdType}=${state.applicationId}` +
      `&${ReturnUrlType}=${this.setReturnLogout()}`;

    this.redirectToApiAuthorizationPath(redirectUrl);
  }

  private setReturnLogout() {
    return encodeURI(this.BASE_URL + ApplicationPaths.LogOutCallback);
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
    // If the url is coming from the query string, check that is either
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
      (state && state.returnUrl) || fromQuery || ApplicationPaths.LoggedOut
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
