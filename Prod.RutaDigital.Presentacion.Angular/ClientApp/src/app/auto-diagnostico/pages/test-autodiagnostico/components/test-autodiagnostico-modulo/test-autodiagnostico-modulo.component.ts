import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-autodiagnostico-modulo',
  templateUrl: './test-autodiagnostico-modulo.component.html',
  styleUrls: []
})
export class TestAutodiagnosticoModuloComponent implements OnInit {

  steps: Array<any>;
  prueba : number = 6;
  constructor() { }

  ngOnInit(): void {
    this.steps = [
                  {
                    step:"1",
                    porcentaje:"0"
                  },{
                    step:"2",
                    porcentaje:"20"
                  },{
                    step:"3",
                    porcentaje:"35"
                  },{
                    step:"4",
                    porcentaje:"50"
                  },{
                    step:"5",
                    porcentaje:"70"
                  },{
                    step:"6",
                    porcentaje:"100"
                  },
                ];
    this.ListarStep();
  }

  ListarStep = () =>{
debugger
   
  }

}
