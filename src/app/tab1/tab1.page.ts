import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from '../shared/storage.service';
import { ClienteService } from '../shared/cliente.service'; // Importamos ClienteService
import { Cliente, Factura, Reserva } from '../shared/cliente.model'; // Importamos correctamente Cliente y Factura

@Component({
  selector: 'app-tab1',
  templateUrl: 'tab1.page.html',
  styleUrls: ['tab1.page.scss']
})
export class Tab1Page implements OnInit {
  cliente?: Cliente;
  facturas: Factura[] = [];
  reservas: Reserva[] = []; 

  constructor(
    private storage: StorageService, 
    private router: Router,
    private clienteService: ClienteService // Inyectamos ClienteService en el constructor de Tab1Page para poder usarlo
  ) {}

  async ngOnInit() {
    await this.loadClientData();
    if (this.cliente?.dni) {
      this.loadFacturas();
      this.loadReservas();
    }
  }

  async loadClientData() {
    this.cliente = await this.storage.get('cliente'); 
    console.log("Cliente desde storage DNI:", this.cliente?.dni);
  }

  //Método para cargar las FACTURAS del cliente
  async loadFacturas() {
    if (!this.cliente?.dni) {
      console.warn("No se pueden cargar facturas sin DNI.");
      return;
    }
  
    try {
      const token = await this.storage.get('token'); 
      if (!token) {
        console.error("No se encontró un token en el almacenamiento.");
        return;
      }

      
    console.log("Token recuperado:", token);
    console.log("DNI del cliente:", this.cliente.dni); //Verificamos si el DNI es correcto
  
    this.clienteService.getFacturasCliente(token, this.cliente.dni).subscribe(
        data => {
          this.facturas = data || []; // Aseguramos que no sea null
          console.log("Facturas cargadas:", this.facturas);
        },
        error => {
          console.error("Error al obtener las facturas:", error);
          this.facturas = [];
        }
      );
    } catch (error) {
      console.error("Error en loadFacturas:", error);
      this.facturas = [];
    }
  }

  //Método para cargar las RESERVAS del cliente

    async loadReservas() {
      if (!this.cliente?.dni) {
        console.warn("No se pueden cargar reservas sin DNI.");
        return;
      }
    
      try {
        const token = await this.storage.get('token');
        if (!token) {
          console.error("No se encontró un token en el almacenamiento.");
          return;
        }
  
        console.log("Token recuperado:", token);
        console.log("DNI del cliente:", this.cliente.dni);
  
        this.clienteService.getReservasCliente(token, this.cliente.dni).subscribe(
          data => {
            this.reservas = data || [];
            console.log("Reservas cargadas:", this.reservas);
          },
          error => {
            console.error("Error al obtener las reservas:", error);
            this.reservas = [];
          }
        );
      } catch (error) {
        console.error("Error en loadReservas:", error);
        this.reservas = [];
      }
    }

  // Navegación a tab2 para ver los detalles de una factura
  verFactura(factura: Factura) {
    if (factura?.id) {
      this.router.navigate(['/tabs/tab2', factura.id]);
    } else {
      console.warn("Factura no válida:", factura);
    }
  }

  // Navegación a tab3 para ver los detalles de una reserva
  verReserva(reservaId: number) {
    this.router.navigate(['/tabs/tab3', reservaId.toString()]); // Convertimos el número a string
  }
}