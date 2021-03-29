import { CargaService } from './service/carga.service';
import { Component, OnInit } from '@angular/core';
import { CargaInicial } from '../Models/cargaInicial'


@Component({
  selector: 'app-carga',
  templateUrl: './carga.component.html',
  styleUrls: ['./carga.component.css']
})
export class CargaComponent implements OnInit {

  constructor( private cargaService: CargaService) { }

  status: any;
  cargaList :any = []
  index:number = 0 
  size: number =10
  search:number= null
  orderBy: string = "Id" 
  orderType: string = "asc"
  
  carga : CargaInicial= {
    tipo: null,
    semana: null,
    mes: null,
    ano: null
  }
  
  
  async ngOnInit() {
    this.cargaList = await this.cargaService.GetTotalCargas()
  }

  async Iniciar()
  {
    await this.cargaService.PostIniciar(this.carga)
    this.load()
  }

  async Entrege(id){
    await this.cargaService.PutEntrega(id)
    this.load()
  }

  async Search(){
    this.cargaList = await this.cargaService.GetTablePagination( this.index,
                                                                   this.size,
                                                                   this.search,
                                                                   this.orderBy,
                                                                   this.orderType)
  }
  load() {
    console.log('sessionStorage', sessionStorage);
    sessionStorage.refresh = true;
    (sessionStorage.refresh == 'true' || !sessionStorage.refresh) 
        && location.reload();
    sessionStorage.refresh = false;
  }
}
 