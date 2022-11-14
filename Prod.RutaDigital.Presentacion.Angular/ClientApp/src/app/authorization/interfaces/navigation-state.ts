import { ApplicationIdType, ReturnUrlType } from '../authorization.constants';

export interface INavigationState {
  [ReturnUrlType]: string;
  [ApplicationIdType]: string;
}
