import { Routes } from '@angular/router';
import { CounterComponent } from './pages/counter/counter.component';
import { FetchDataComponent } from './pages/fetch-data/fetch-data.component';
import { HomeComponent } from './pages/home/home.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full',
    data: { state: 'home' },
  },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
];
