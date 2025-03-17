import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClienteService } from '../shared/cliente.service';
import { Factura, Linea } from '../shared/cliente.model';
import { StorageService } from '../shared/storage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tab2',
  templateUrl: './tab2.page.html',
  styleUrls: ['./tab2.page.scss'],
})
export class Tab2Page implements OnInit {
  factura: Factura = {
    id: 0,
    fecha: new Date(),
    esPagada: false,
    esAnulada: false,
    lineas: [], 
    dameTotal: 0
  };
  facturaId: number | null = null;

  constructor(
    private storage: StorageService, 
    private route: ActivatedRoute,
    private clienteService: ClienteService,
    private router: Router  // Servicio del Router
  ) {}

  async ngOnInit() {
    this.route.params.subscribe(params => {
      this.facturaId = Number(params['id']);
      if (this.facturaId) {
        this.loadFactura();
      }
    });
  }

  async loadFactura() {
    if (!this.facturaId) {
      console.error("No hay un ID de factura válido.");
      return;
    }

    try {
      const token = await this.storage.get('token'); 
      if (!token) {
        console.error("No se encontró un token en el almacenamiento.");
        return;
      }

      console.log("Token recuperado:", token);
      console.log("Factura ID:", this.facturaId);

      this.clienteService.getFacturaById(token, this.facturaId).subscribe(
        (data: Factura) => {
          this.factura = {
            ...data,
            lineas: data.lineas ?? [] 
          };
          console.log("Factura cargada:", this.factura);
        },
        error => {
          console.error("Error al cargar la factura:", error);
        }
      );
    } catch (error) {
      console.error("Error en loadFactura:", error);
    }
  }

  //Función para ver detalles de una línea de factura
  verDetalleLinea(linea: Linea) {
    this.router.navigate(['/tabs/linea-detalle', linea.numLinea ]); 
  }
}


