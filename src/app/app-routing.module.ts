import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

//Definimos las rutas de la aplicación

const routes: Routes = [
  {
    path: 'tabs',
    children: [
      {
        path: '',
        loadChildren: () => import('./tabs/tabs.module').then(m => m.TabsPageModule)
      },
      {
        path: 'tab2/:id',  // Nueva ruta para ver los detalles de una factura
        loadChildren: () => import('./tab2/tab2.module').then(m => m.Tab2PageModule)
      },

      {
        path: 'tab3/:id', // Nueva ruta para ver los detalles de una reserva
        loadChildren: () => import('./tab3/tab3.module').then(m => m.Tab3PageModule)
      },

      {
        path: 'linea-detalle/:numLinea',  // Nueva ruta para los detalles de la línea
        loadChildren: () => import('./linea-detalle/linea-detalle.module').then(m => m.LineaDetallePageModule)
      }
    ]
  },

  {
    path: '',
    loadChildren: () => import('./login/login.module').then(m => m.LoginPageModule)
  },
  
  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full'
  }

];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
