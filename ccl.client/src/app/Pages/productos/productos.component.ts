import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from "../../../environments/environment";
import { HttpHeaders } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {
  productos: any[] = [];
  private apiUrl = `${environment.apiUrl}/api/Productos/inventario`;

  constructor(private http: HttpClient, private router: Router, private cookieService: CookieService) { }


  ngOnInit(): void {
    this.obtenerProductos();
  }

  obtenerProductos() {
    const token = this.cookieService.get('auth_token'); // Obtiene el token almacenado    
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
      this.http.get<any[]>(this.apiUrl, { headers }).subscribe(
      (data) => { this.productos = data; },
      (error) => { console.error('Error al obtener productos', error); }
    );
  }

  editarProducto(producto: any) {
    this.router.navigate(['/producto-form', producto.id]);
  }


  nuevoProducto() {
    this.router.navigate(['/producto-form']);
  }

}
