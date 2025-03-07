import { Injectable, inject } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import * as  jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private tokenKey = 'auth_token';
  private cookieService = inject(CookieService);
  private router = inject(Router);

  setToken(token: string): void {
    this.cookieService.set(this.tokenKey, token, { path: '/' });
  }

  getToken(): string | null {
    return this.cookieService.get(this.tokenKey) || null;
  }

  isAuthenticated(): boolean {
    const token = this.getToken();
    if (!token) return false;

    try {
      const decoded: any = jwt_decode.jwtDecode(token); 
      const now = Math.floor(Date.now() / 1000);
      return decoded?.exp > now; 
    } catch (error) {
      return false;
    }
  }

  logout(): void {
    this.cookieService.delete(this.tokenKey, '/');
    this.router.navigate(['/login']);
  }
}
