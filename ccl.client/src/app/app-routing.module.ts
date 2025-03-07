import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Pages/login/login.component';
import { ProductosComponent } from './Pages/productos/productos.component';
import { ProductoFormComponent } from './Pages/producto-form/producto-form.component';

const routes: Routes = [
  { path: '', component: LoginComponent },  
  { path: 'login', component: LoginComponent },
  { path: 'productos', component: ProductosComponent },
  { path: 'producto-form/:id', component: ProductoFormComponent },
  { path: 'producto-form', component: ProductoFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
