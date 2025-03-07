import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from "../../../environments/environment";
import { HttpHeaders } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-producto-form',
  templateUrl: './producto-form.component.html',
  styleUrls: ['./producto-form.component.css']
})
export class ProductoFormComponent implements OnInit {
  producto: any = { id: 0, nombre: '', cantidad: 0 };
  private apiUrl = `${environment.apiUrl}`;
  errorMessage: string = "";
  constructor(private route: ActivatedRoute, private http: HttpClient, private cookieService: CookieService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.obtenerProducto(id);
    }
  }

  obtenerProducto(id: string) {
    const token = this.cookieService.get('auth_token'); // Obtiene el token almacenado    
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);   
    this.http.get<any[]>(`${this.apiUrl}/api/Productos/inventario`, { headers }).subscribe(
      (productos) => {      
        this.producto = productos.find(p => p.id === Number(id)) || null;

        if (!this.producto) {
          console.warn(`No se encontró un producto con el ID: ${id}`);
        }
      },
      (error) => {
        console.error('Error al obtener la lista de productos', error);
      }
    );
  }

  guardarProducto() {
    if (!this.producto.nombre.trim()) {
      this.errorMessage = "⚠️ El nombre del producto no puede estar vacío.";
      return;
    }
    if (!this.producto || !this.producto.nombre || this.producto.cantidad <= 0) {
      console.warn("Los datos del producto no son válidos.");
      return;
    }

    const token = this.cookieService.get('auth_token'); // Obtiene el token almacenado
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    this.http.post(`${this.apiUrl}/api/Productos/movimiento`, this.producto, { headers }).subscribe(
        (response) => {
          console.log("Producto guardado con éxito", response);
        },
        (error) => {
          console.error("Error al guardar el producto", error);
        }
    );

    window.history.back(); 
    
  }

  cancelar() {
    window.history.back(); 
  }



}
