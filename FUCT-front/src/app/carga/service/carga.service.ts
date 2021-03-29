import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CargaService {

  constructor(private http: HttpClient) { }

  GetTotalCargas(){
    return new Promise((resolve, reject) => {
      return this.http
        .get(
          `${environment.todasCargas}`
        )
        .subscribe(
          res => {
            resolve(res);
          },
          err => {
            console.log(err);
            reject(err);
          }
        );
    });
  }

  PutEntrega(id){
  let teste = `${environment.iniciarCarga}${id}`
  console.log(teste)
    return new Promise((resolve, reject) => {
    return this.http.put(`${environment.iniciarCarga}${id}`, null)
    .subscribe(
      res => {
        resolve(res);
      },
      err => {
        console.log(err);
        reject(err);
      }
      );
  });
}

  GetTablePagination( index, size, search, orderBy, orderType){
    return new Promise((resolve, reject) => {
      return this.http
        .get(
          `${environment.PagedCargas}?index=${index}&size=${size}&search=${search}&ordeBy=${orderBy},&orderType=${orderType}`
        )
        .subscribe(
          res => {
            resolve(res);
          },
          err => {
            console.log(err);
            reject(err);
          }
        );
    });
  }


PostIniciar(carga)
{
  return new Promise((resolve, reject) => {
    return this.http
      .post<any>(`${environment.iniciarCarga}`, carga)
      .subscribe(
        res => {
          resolve(res);
        },
        err => {
          console.log(err);
          reject(err);
        }
      );
    }); 
  }

}

