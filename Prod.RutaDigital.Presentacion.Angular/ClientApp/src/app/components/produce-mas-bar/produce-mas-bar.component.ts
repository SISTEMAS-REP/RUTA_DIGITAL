import { Component, OnInit } from '@angular/core';
import { BannerRepository } from 'src/app/repositories/banner.repository';
import { ComunRepository } from 'src/app/repositories/comun.repository';

@Component({
  selector: 'app-produce-mas-bar',
  templateUrl: './produce-mas-bar.component.html'
})
export class ProduceMasBarComponent implements OnInit {
  isCokies: Boolean = false;
  id_usuario: number = 78128;
  constructor(
    private comunRepository: BannerRepository,
  ) { }

  ngOnInit(): void {
    if(this.id_usuario != null){
      this.isCokies = true;
    }
  }

  RedireccionarLoginUnico = (item) =>{
    var request: any = {
      id_tipo_url: item
    };
    this.comunRepository.RedireccionarLoginUnico(request)
    .subscribe({
      next: (data : any) => {
        debugger
      },
      error: (err) => {
       
      },
    });
  }

  // fnObtenerIdusuarii = () =>{
    
  // }

}
