import { Injectable } from '@angular/core';
import {Observable, of, throwError} from 'rxjs';
import {HttpClient, HttpHeaders, HttpResponse} from '@angular/common/http';
import {catchError} from 'rxjs/operators';
import { Storage } from '@ionic/storage-angular'

import {Cliente} from './cliente.model';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Access-Control-Allow-Origin' : 'http://localhost:8100'
    })
  };

  const httpOptionsLogin = {
    headers: new HttpHeaders({'Content-Type':  'application/json'}) 
    //observe: 'response'
  };

@Injectable()

export class ClienteService {


  private readonly HS_API_URL = 'https://localhost:44358/api';
  private token : string = "";
  private headers = new HttpHeaders;


  constructor(private http: HttpClient,
    private storage: Storage) {
      

  }

  public RecuperarToken (){
    
    var promise = this.storage.get('token').then (token => {
      this.token = token;
      this.headers = new HttpHeaders ({'Authorization': this.token});
    });
    return promise;
  }



  public login(dni: string, password: string): Observable<any> {
 
    let cli:Cliente = {DNI: dni, Pass: password};
   
     return this.http.post(`${this.HS_API_URL}/Cliente_anonimo/Login`, cli, {responseType:'text'})
    .pipe(
        catchError((err) => {
          console.log("Error en el login");
          console.error(err);
          return throwError(err);
        }
        )
      );
  }

  public getClientePorDNI(token:string): Observable<Cliente>{

       this.headers = new HttpHeaders ({'Authorization': token});
       return this.http.get<Cliente>(`${this.HS_API_URL}/ClienteRegistrado`, {headers:this.headers});   
   }

   public getReservasCliente(dni:string): Observable<any>{

    return this.http.get<any>(`${this.HS_API_URL}/Reserva/DameReservas?idClienteRegistrado${dni}`, {headers:this.headers});   
  }

  public getFacturas(dni:string): Observable<any>{

    return this.http.get<any>(`${this.HS_API_URL}/Factura/Factura_dameTotal`, {headers:this.headers});   
  }
  
 }

