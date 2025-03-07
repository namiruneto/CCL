import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CookieService } from 'ngx-cookie-service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Pages/login/login.component';
import { FormsModule } from '@angular/forms';
import { ProductosComponent } from './Pages/productos/productos.component';
import { ProductoFormComponent } from './Pages/producto-form/producto-form.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
          ProductosComponent,
          ProductoFormComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule 
  ],
  providers: [CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
