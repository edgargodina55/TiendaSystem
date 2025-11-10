import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = environment.apiUrl; // ej. https://localhost:7262/api

  constructor(private http: HttpClient) {}

  // GET: /users
  getAll(): Observable<any> {
    return this.http.get(`${this.apiUrl}/users`);
  }

  // POST: /users
  create(data: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/users`, data);
  }

  // PUT: /users/{id}
  update(id: number, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/users/${id}`, data);
  }

  // DELETE: /users/{id}
  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/users/${id}`);
  }
}
