import {
  BrowserModule,
} from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { CounterComponent } from './demo/counter/counter.component';
import { WeatherForecastComponent } from './demo/weather-forecast/weather-forecast.component';
import { SharedModule } from './shared/shared.module';
import { FooterComponent } from './components/footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { routes } from './app.routes';
import { ProduceMasBarComponent } from './components/produce-mas-bar/produce-mas-bar.component';
import { HeaderComponent } from './components/header/header.component';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ProduceMasBarComponent,
    NavMenuComponent,
    FooterComponent,
    CounterComponent,
    WeatherForecastComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    CarouselModule,
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
