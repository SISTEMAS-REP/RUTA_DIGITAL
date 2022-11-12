import { Injectable } from '@angular/core';
import { BehaviorSubject, concat, from, Observable } from 'rxjs';
import { filter, map, mergeMap, take, tap } from 'rxjs/operators';
import { INavigationState } from './interfaces/navigation-state';
import { ExtranetUser } from '../shared/interfaces/extranet-user';
import { BaseService } from '../shared/services/base.service';

export type IAuthenticationResult =
  | SuccessAuthenticationResult
  | FailureAuthenticationResult
  | RedirectAuthenticationResult;

export interface SuccessAuthenticationResult {
  status: AuthenticationResultStatus.Success;
  state: any;
}

export interface FailureAuthenticationResult {
  status: AuthenticationResultStatus.Fail;
  message: string;
}

export interface RedirectAuthenticationResult {
  status: AuthenticationResultStatus.Redirect;
  state: INavigationState;
}

export enum AuthenticationResultStatus {
  Success,
  Redirect,
  Fail,
}

@Injectable({
  providedIn: 'root',
})
export class AuthorizeService extends BaseService {
  getControllerUrl(): string {
    return 'authorization';
  }

  private _user: ExtranetUser;
  private userSubject: BehaviorSubject<ExtranetUser | null> =
    new BehaviorSubject(null);

  get isLoggedIn(): boolean {
    return !!this.user;
  }

  get user(): ExtranetUser {
    return this._user;
  }

  public isAuthenticated(): Observable<boolean> {
    return this.getUser().pipe(map((u) => !!u));
  }

  public getUser(): Observable<ExtranetUser | null> {
    return concat(
      this.userSubject.pipe(
        take(1),
        filter((u) => !!u)
      ),
      this.getUserFromRemote().pipe(
        filter((u) => !!u),
        tap((u) => {
          this._user = u;
          this.userSubject.next(u);
        })
      ),
      this.userSubject.asObservable()
    );
  }

  public async signIn(state: INavigationState): Promise<IAuthenticationResult> {
    try {
      // > el returnurl debe tener login-callback
      return this.redirect(state);
    } catch (redirectError) {
      console.log('Redirect authentication error: ', redirectError);
      return this.error(redirectError);
    }
    /*}
    }*/
  }

  public async completeSignIn(url: string): Promise<IAuthenticationResult> {
    try {
      //await this.ensureUserManagerInitialized();

      // TODO: hacer petición al endpoint de check
      //const response = await this.httpClient.get<ApiResponse<Ap>>('check');
      //const user = await this.userManager.signinCallback(url);
      //this.userSubject.next(user && (user.profile as any));
      //return this.success(user && user.state);
      const user = await this.getUser().pipe();
      console.log('user', user);
      return this.success();
    } catch (error) {
      console.log('There was an error signing in: ', error);
      return this.error('There was an error signing in.');
    }
  }

  public async signOut(state: any): Promise<IAuthenticationResult> {
    try {
      //await this.ensureUserManagerInitialized();
      //await this.userManager.signoutPopup(this.createArguments());
      this.userSubject.next(null);
      return this.success(state);
    } catch (popupSignOutError) {
      console.log('Popup signout error: ', popupSignOutError);
      try {
        //await this.userManager.signoutRedirect(this.createArguments(state));
        return this.redirect(state);
      } catch (redirectSignOutError) {
        console.log('Redirect signout error: ', popupSignOutError);
        return this.error(redirectSignOutError);
      }
    }
  }

  public async completeSignOut(url: string): Promise<IAuthenticationResult> {
    //await this.ensureUserManagerInitialized();
    try {
      //const signoutResponse = await this.userManager.signoutCallback(url);
      //this.userSubject.next(null);
      //return this.success(signoutResponse && signoutResponse.state.data);
      return this.success();
    } catch (error) {
      console.log(`There was an error trying to log out '${error}'.`);
      return this.error(error);
    }
  }

  private createArguments(state?: any): any {
    return { useReplaceToNavigate: true, data: state };
  }

  private error(message: string): IAuthenticationResult {
    return { status: AuthenticationResultStatus.Fail, message };
  }

  private success(state?: any): IAuthenticationResult {
    return { status: AuthenticationResultStatus.Success, state };
  }

  private redirect(state: INavigationState): IAuthenticationResult {
    return { status: AuthenticationResultStatus.Redirect, state };
  }

  private getUserFromRemote(): Observable<ExtranetUser> {
    return this.get('').pipe(map((response) => response.data as ExtranetUser));
  }
}
