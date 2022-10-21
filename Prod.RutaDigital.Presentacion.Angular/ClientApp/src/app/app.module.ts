import {
  BrowserModule,
  BrowserTransferStateModule,
} from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './pages/home/home.component';
import { CounterComponent } from './pages/counter/counter.component';
import { FetchDataComponent } from './pages/fetch-data/fetch-data.component';
import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './shared/shared.module';
import { FooterComponent } from './components/footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { routes } from './app.routes';

@NgModule({
  declarations: [
    AppComponent,

    NavMenuComponent,
    HomeComponent,
    FooterComponent,

    CounterComponent,
    FetchDataComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    //AppRoutingModule,
    RouterModule.forRoot(routes, {
      //initialNavigation: 'enabled',
      relativeLinkResolution: 'legacy',
    }),
    SharedModule,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
