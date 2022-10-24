//import { environment } from '../../../environments/environment';

export const ApplicationName = document.baseURI
  .replace(/\//g, '')
  .replace(/:/g, '')
  .split('.')
  .join('');

export const ReturnUrlType = 'returnUrl';

export const QueryParameterNames = {
  ReturnUrl: ReturnUrlType,
  Message: 'message',
};

export const LogoutActions = {
  Logout: 'logout',
  LoggedOut: 'logged-out',
  LogoutCallback: 'logout-callback',
};

export const LoginActions = {
  Login: 'login',
  LoginCallback: 'login-callback',
  LoginFailed: 'login-failed',
  Profile: 'profile',
  Register: 'register',
};

let applicationPaths: ApplicationPathsType = {
  DefaultLoginRedirectPath: '/',
  //ApiAuthorizationClientConfigurationUrl: `${environment.loginUnicoUrl}_configuration/${ApplicationName}`,

  Login: `authentication/${LoginActions.Login}`,
  LoginFailed: `authentication/${LoginActions.LoginFailed}`,
  LoginCallback: `authentication/${LoginActions.LoginCallback}`,
  Register: `authentication/${LoginActions.Register}`,
  Profile: `authentication/${LoginActions.Profile}`,

  LogOut: `authentication/${LogoutActions.Logout}`,
  LoggedOut: `authentication/${LogoutActions.LoggedOut}`,
  LogOutCallback: `authentication/${LogoutActions.LogoutCallback}`,

  LoginPathComponents: [],
  LoginFailedPathComponents: [],
  LoginCallbackPathComponents: [],
  RegisterPathComponents: [],
  ProfilePathComponents: [],

  LogOutPathComponents: [],
  LoggedOutPathComponents: [],
  LogOutCallbackPathComponents: [],

  Check: `authorization/check`,
  IdentityLogin: `auth/login-person`,
  IdentityRegister: `auth/register-person`,
  IdentityManage: `home/profile`,
  //IdentityLoginPath: `${environment.loginUnicoUrl}auth/login-person`,
  //IdentityRegisterPath: `${environment.loginUnicoUrl}auth/register`,
  //IdentityManagePath: `${environment.loginUnicoUrl}profile`,
};

applicationPaths = {
  ...applicationPaths,
  LoginPathComponents: applicationPaths.Login.split('/'),
  LoginFailedPathComponents: applicationPaths.LoginFailed.split('/'),
  RegisterPathComponents: applicationPaths.Register.split('/'),
  ProfilePathComponents: applicationPaths.Profile.split('/'),

  LogOutPathComponents: applicationPaths.LogOut.split('/'),
  LoggedOutPathComponents: applicationPaths.LoggedOut.split('/'),
  LogOutCallbackPathComponents: applicationPaths.LogOutCallback.split('/'),
};

interface ApplicationPathsType {
  readonly DefaultLoginRedirectPath: string;
  //readonly ApiAuthorizationClientConfigurationUrl: string;

  readonly Login: string;
  readonly LoginFailed: string;
  readonly LoginCallback: string;
  readonly Register: string;
  readonly Profile: string;

  readonly LogOut: string;
  readonly LoggedOut: string;
  readonly LogOutCallback: string;

  readonly LoginPathComponents: string[];
  readonly LoginFailedPathComponents: string[];
  readonly LoginCallbackPathComponents: string[];
  readonly RegisterPathComponents: string[];
  readonly ProfilePathComponents: string[];

  readonly LogOutPathComponents: string[];
  readonly LoggedOutPathComponents: string[];
  readonly LogOutCallbackPathComponents: string[];

  readonly Check: string;
  readonly IdentityLogin: string;
  readonly IdentityRegister: string;
  readonly IdentityManage: string;
  //readonly IdentityCheckPath: string;
  //readonly IdentityLoginPath: string;
  //readonly IdentityRegisterPath: string;
  //readonly IdentityManagePath: string;
}

export const ApplicationPaths: ApplicationPathsType = applicationPaths;
