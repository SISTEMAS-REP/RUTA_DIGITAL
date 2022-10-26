import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { BannerResponse } from '../interfaces/banner';
import { BannerService } from '../services/banner.service';

@Injectable({
  providedIn: 'root',
})
export class BannerRepository {
  constructor(private bannerService: BannerService) {}

  ListarBannerPrincipal = (): Observable<BannerResponse[]> => {
    debugger
    return this.bannerService
      .ListarBannerPrincipal()
      .pipe(map((response) => response.data as BannerResponse[]));
  };

  ListarBannerPiePagina = (): Observable<BannerResponse[]> => {
    return this.bannerService
      .ListarBannerPiePagina()
      .pipe(map((response) => response.data as BannerResponse[]));
  };
}
