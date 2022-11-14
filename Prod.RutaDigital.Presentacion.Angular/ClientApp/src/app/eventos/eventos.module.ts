import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EventosComponent } from './eventos.component';
import { EventosSeleccionComponent } from './components/eventos-seleccion/eventos-seleccion.component';
import { GoogleMapsModule } from '@angular/google-maps';
import { EventosRoutingModule } from './eventos-routing.module';

@NgModule({
  declarations: [EventosComponent, EventosSeleccionComponent],
  imports: [CommonModule, EventosRoutingModule, GoogleMapsModule],
})
export class EventosModule {}
