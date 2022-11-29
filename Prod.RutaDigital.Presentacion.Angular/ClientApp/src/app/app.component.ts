import { Component, OnInit } from '@angular/core';
import { Meta, Title } from '@angular/platform-browser';
import { NavigationEnd, Router } from '@angular/router';
import { AuthorizeService } from './authorization/authorize.service';
import { AppService } from './shared/services/app.service';
import { AutodiagnosticoService } from './autodiagnostico/autodiagnostico.service';
import { AutodiagnosticoRepository } from './autodiagnostico/autodiagnostico.repository';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent implements OnInit {
  isAuthenticated: boolean = false;
  verificacionAutodiagnostico: boolean;
  verificacionAutodiagnosticoHistorico: boolean;

  constructor(
    private router: Router,
    private title: Title,
    private meta: Meta,
    private appService: AppService,
    private authorizeService: AuthorizeService,
    private autodiagnosticoRepository: AutodiagnosticoRepository
  ) {
    this.authorizeService.isAuthenticated().subscribe((status) => {
      this.isAuthenticated = status;
    });

    this.autodiagnosticoRepository
      .verificarAutodiagnostico()
      .subscribe((status) => {
        this.verificacionAutodiagnostico = status;
      });

    this.autodiagnosticoRepository
      .verificarAutodiagnosticoHistorico()
      .subscribe((status) => {
        this.verificacionAutodiagnosticoHistorico = status;
      });
  }

  public ngOnInit() {
    this.updateTitleAndMeta();
    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
        return;
      }
      window.scrollTo(0, 0);
    });
  }

  public getState(outlet: any) {
    return outlet.activatedRouteData.state;
  }

  private updateTitleAndMeta() {
    this.title.setTitle(this.appService.appData.content['applicationTitle']);
    this.meta.addTags([
      {
        name: 'description',
        content: this.appService.appData.content['applicationDescription'],
      },
      {
        property: 'og:title',
        content: this.appService.appData.content['applicationTitle'],
      },
      {
        property: 'og:description',
        content: this.appService.appData.content['applicationDescription'],
      },
    ]);
  }
}
