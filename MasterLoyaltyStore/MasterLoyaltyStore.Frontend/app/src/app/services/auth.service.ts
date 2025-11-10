import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserRole } from '../constants/enums/userRole.enum';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = environment.apiUrl;

  constructor(private http:HttpClient) { }

  login(data:{ email : string; password : string}): Observable<any>{
    return this.http.post(`${this.apiUrl}/Login/Authenticate`,data);
  }

  // guardar token y user (puedes llamarlo desde el login.component.ts)
  storeSession(token: string, user: any): void {
    localStorage.setItem('token', token);
    localStorage.setItem('user', JSON.stringify(user));
  }

  // saber si está logueado
  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  isAdmin(): boolean{
    const userStorage = localStorage.getItem("user");
   
    if(!userStorage) return false;

      const role = JSON.parse(localStorage.getItem('user') || '{}').roleId || null;
      return role === UserRole.Admin
    
  }

  isCustomer(): boolean{
    const userStorage = localStorage.getItem("user");
    if(!userStorage) return false;
      const role = JSON.parse(localStorage.getItem('user') || '{}').roleId || null;
      return role === UserRole.Customer
    
  }

  // obtener token (para interceptor)
  getToken(): string | null {
    return localStorage.getItem('token');
  }

  // cerrar sesión
  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    sessionStorage.clear();
  }

}
