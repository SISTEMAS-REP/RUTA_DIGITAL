import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EventosRoutingModule } from './eventos-routing.module';
import { EventosComponent } from './eventos.component';
import { RouterModule } from '@angular/router';
import { EventosSeleccionComponent } from './components/eventos-seleccion/eventos-seleccion.component';
import { CarouselModule } from 'ngx-owl-carousel-o';




@NgModule({
  declarations: [
    EventosComponent,
    EventosSeleccionComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    EventosRoutingModule,
    CarouselModule,
    
  ],
  providers: [
 ],

})
export class EventosModule {}
