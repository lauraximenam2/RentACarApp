import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClienteService } from '../shared/cliente.service';
import { StorageService } from '../shared/storage.service';
import { Reserva } from '../shared/cliente.model';

@Component({
  selector: 'app-tab3',
  templateUrl: 'tab3.page.html',
  styleUrls: ['tab3.page.scss']
})
export class Tab3Page implements OnInit {
  reserva?: Reserva;

  constructor(
    private route: ActivatedRoute,
    private clienteService: ClienteService,
    private storage: StorageService
  ) {}

  async ngOnInit() {
    const reservaId = this.route.snapshot.paramMap.get('id');
    if (reservaId) {
      const token = await this.storage.get('token');  // Recupera el token
      this.obtenerReserva(token, Number(reservaId));
    }
  }

  obtenerReserva(token: string, reservaId: number) {
    this.clienteService.dameReserva(token, reservaId).subscribe(
      (data) => {
        this.reserva = data;
        console.log("Reserva obtenida:", this.reserva);
      },
      (error) => {
        console.error("Error al obtener la reserva:", error);
      }
    );
  }
}
