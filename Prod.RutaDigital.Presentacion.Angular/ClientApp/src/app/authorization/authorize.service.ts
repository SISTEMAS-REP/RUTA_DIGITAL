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

  public async completeSignIn(): Promise<IAuthenticationResult> {
    try {
      const user = await this.getUser().pipe(take(1));
      console.log('user', user);
      return this.success();
    } catch (error) {
      console.log('There was an error signing in: ', error);
      return this.error('There was an error signing in.');
    }
  }

  public async completeSignOut(): Promise<IAuthenticationResult> {
    //await this.ensureUserManagerInitialized();
    try {
      this.userSubject.next(null);
      return this.success();
    } catch (error) {
      console.log(`There was an error trying to log out '${error}'.`);
      return this.error(error);
    }
  }

  private error(message: string): IAuthenticationResult {
    return { status: AuthenticationResultStatus.Fail, message };
  }

  private success(state?: any): IAuthenticationResult {
    return { status: AuthenticationResultStatus.Success, state };
  }

  private getUserFromRemote(): Observable<ExtranetUser> {
    return this.get('').pipe(map((response) => response.data as ExtranetUser));
  }
}
