import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Storage } from '@ionic/storage-angular';
import { Cliente, Factura, Reserva, Coche, Coches } from './cliente.model';

@Injectable({
  providedIn: 'root'
})

export class ClienteService {
  private readonly HS_API_URL = 'https://localhost:5001/api';
  private token: string = '';
  private headers = new HttpHeaders();

  constructor(private http: HttpClient, private storage: Storage) {}

  // Obtener el token de almacenamiento
  public async RecuperarToken() {
    this.token = await this.storage.get('token');
    this.headers = new HttpHeaders({
      'Authorization': `Bearer ${this.token}`,
      'Content-Type': 'application/json'
    });
  }

  // Iniciar sesión
  public login(dni: string, password: string): Observable<any> {
    let cli: Cliente = { dni: dni, pass: password };

    return this.http.post(`${this.HS_API_URL}/Cliente_anonimo/Login`, cli, { responseType: 'text' })
      .pipe(
        catchError((err) => {
          console.log('Error en el login');
          console.error(err);
          return throwError(err);
        })
      );
  }

  // Obtenemos perfil del cliente
  public getClientePorDNI(token: string): Observable<Cliente> {
    this.headers = new HttpHeaders ({ 'Authorization': token });
    return this.http.get<Cliente>(`${this.HS_API_URL}/ClienteRegistrado`, { headers: this.headers });
  }


  //Obtenemos facturas del cliente 
  public getFacturasCliente(token: string,  dni: string): Observable<Factura[]> {
    this.headers = new HttpHeaders ({ 'Authorization': token }); 
    return this.http.get<Factura[]>(`${this.HS_API_URL}/Factura/ObtenerFacturasPorCliente?dni=${dni}`, { headers: this.headers });
  }

    //Obtenemos facturas del cliente 
    public getReservasCliente(token: string, idClienteRegistrado: string): Observable<Reserva[]> {
      this.headers = new HttpHeaders ({ 'Authorization': token }); 
      return this.http.get<Reserva[]>(`${this.HS_API_URL}/Reserva/DameReservas?idClienteRegistrado=${idClienteRegistrado}`, { headers: this.headers });
    }

}

  //aqui se ponen lo métodos que se vinculan con la fachada REst

  