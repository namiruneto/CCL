import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { environment } from "../../../environments/environment";
import { Router } from '@angular/router'; 

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  errorMessage: string = '';

  private apiUrl = `${environment.apiUrl}/api/Auth/Login`;
  constructor(private http: HttpClient, private cookieService: CookieService, private router: Router) { }

  onSubmit() {
    const loginData = {
      username: this.username,
      password: this.password
    };

    this.http.post<any>(this.apiUrl, loginData).subscribe(
      (response) => {
        if (response.success) {
          this.cookieService.set('auth_token', response.token, 1, '/');

          this.router.navigate(['/productos']);
        } else {
          this.errorMessage = response.message;
        }
      },
      (error) => {
        this.errorMessage = 'Error en la autenticación';
        console.error(error);
      }
    );
  }
}
