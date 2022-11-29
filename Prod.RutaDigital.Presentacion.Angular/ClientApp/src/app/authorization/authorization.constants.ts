export const ApplicationName = document.baseURI
  .replace(/\//g, '')
  .replace(/:/g, '')
  .split('.')
  .join('');

export const ReturnUrlType = 'returnUrl';

export const ApplicationIdType = 'applicationId';

export const QueryParameterNames = {
  ReturnUrl: ReturnUrlType,
  ApplicationId: ApplicationIdType,
  Message: 'message',
};

export const LogoutActions = {
  Logout: 'logout',
  LoggedOut: 'logged-out',
  LogoutCallback: 'logout-callback',
};

export const LoginActions = {
  LoginPerson: 'login-person',
  LoginCompany: 'login-company',
  LoginCallback: 'login-callback',
  LoginFailed: 'login-failed',
  Profile: 'profile',
  Register: 'register',
};

let applicationPaths: ApplicationPathsType = {
  DefaultLoginRedirectPath: '/',
  DefaultLogoutRedirectPath: '/',

  LoginPerson: `authentication/${LoginActions.LoginPerson}`,
  LoginCompany: `authentication/${LoginActions.LoginCompany}`,
  LoginFailed: `authentication/${LoginActions.LoginFailed}`,
  LoginCallback: `authentication/${LoginActions.LoginCallback}`,
  Register: `authentication/${LoginActions.Register}`,
  Profile: `authentication/${LoginActions.Profile}`,

  LogOut: `authentication/${LogoutActions.Logout}`,
  LoggedOut: `authentication/${LogoutActions.LoggedOut}`,
  LogOutCallback: `authentication/${LogoutActions.LogoutCallback}`,

  LoginPersonPathComponents: [],
  LoginCompanyPathComponents: [],
  LoginFailedPathComponents: [],
  LoginCallbackPathComponents: [],
  RegisterPathComponents: [],
  ProfilePathComponents: [],

  LogOutPathComponents: [],
  LoggedOutPathComponents: [],
  LogOutCallbackPathComponents: [],

  Check: `authorization/check`,
  IdentityLoginPerson: `auth/login/person`,
  IdentityLoginCompany: `auth/login/company`,
  IdentityRegister: `auth/register-person`,
  IdentityProfile: `account/profile`,
  IdentityLogout: `auth/logout`,
};

applicationPaths = {
  ...applicationPaths,
  LoginPersonPathComponents: applicationPaths.LoginPerson.split('/'),
  LoginCompanyPathComponents: applicationPaths.LoginCompany.split('/'),
  LoginFailedPathComponents: applicationPaths.LoginFailed.split('/'),
  RegisterPathComponents: applicationPaths.Register.split('/'),
  ProfilePathComponents: applicationPaths.Profile.split('/'),

  LogOutPathComponents: applicationPaths.LogOut.split('/'),
  LoggedOutPathComponents: applicationPaths.LoggedOut.split('/'),
  LogOutCallbackPathComponents: applicationPaths.LogOutCallback.split('/'),
};

interface ApplicationPathsType {
  readonly DefaultLoginRedirectPath: string;
  readonly DefaultLogoutRedirectPath: string;
  //readonly ApiAuthorizationClientConfigurationUrl: string;

  readonly LoginPerson: string;
  readonly LoginCompany: string;
  readonly LoginFailed: string;
  readonly LoginCallback: string;
  readonly Register: string;
  readonly Profile: string;

  readonly LogOut: string;
  readonly LoggedOut: string;
  readonly LogOutCallback: string;

  readonly LoginPersonPathComponents: string[];
  readonly LoginCompanyPathComponents: string[];
  readonly LoginFailedPathComponents: string[];
  readonly LoginCallbackPathComponents: string[];
  readonly RegisterPathComponents: string[];
  readonly ProfilePathComponents: string[];

  readonly LogOutPathComponents: string[];
  readonly LoggedOutPathComponents: string[];
  readonly LogOutCallbackPathComponents: string[];

  readonly Check: string;
  readonly IdentityLoginPerson: string;
  readonly IdentityLoginCompany: string;
  readonly IdentityRegister: string;
  readonly IdentityProfile: string;
  readonly IdentityLogout: string;
}

export const ApplicationPaths: ApplicationPathsType = applicationPaths;
