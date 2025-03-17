import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-linea-detalle',
  templateUrl: './linea-detalle.page.html',
  styleUrls: ['./linea-detalle.page.scss'],
})
export class LineaDetallePage implements OnInit {
  numLinea: number = 0;
  precio: number = 0;

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    this.numLinea = Number(this.route.snapshot.paramMap.get('numLinea'));
    this.precio = Number(this.route.snapshot.paramMap.get('precio')); 
  }
}
