import { ReturnUrlType } from '../authorization.constants';

export interface INavigationState {
  [ReturnUrlType]: string;
}
