import { Inject, Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { map, Observable, of, tap } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { LocalStorageService } from './local-storage.service';

const APP_DATA_KEY = 'appData';

export function appServiceFactory(
  appService: AppService
): () => Observable<IApplicationConfig> {
  return () => appService.getAppData();
}

@Injectable({
  providedIn: 'root',
})
export class AppService extends ApiService {
  getControllerUrl(): string {
    return 'app';
  }

  constructor(
    @Inject('BASE_URL') _baseUrl: string,
    _httpClient: HttpClient,
    private storageService: LocalStorageService
  ) {
    super(_baseUrl, _httpClient);
  }

  public get appData(): IApplicationConfig {
    var appData = this.storageService.getAny(APP_DATA_KEY);
    if (appData && appData !== null && appData !== 'undefined') {
      return JSON.parse(appData);
    }

    return undefined;
  }

  getAppData(): Observable<IApplicationConfig> {
    const appData = this.appData;

    if (!appData || appData === null) {
      return this.get('').pipe(
        map((response) => response.data as IApplicationConfig),
        tap((data) => console.log('getAppData', data)),
        tap((data) =>
          this.storageService.set(APP_DATA_KEY, JSON.stringify(data))
        )
      );
    }

    return of(appData);
  }
}
