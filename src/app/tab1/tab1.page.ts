import { Component } from '@angular/core';
import { Cliente } from '../shared/cliente.model';


@Component({
  selector: 'app-tab1',
  templateUrl: 'tab1.page.html',
  styleUrls: ['tab1.page.scss']
})
export class Tab1Page {
  cliente?:Cliente;

  constructor() {}
}
