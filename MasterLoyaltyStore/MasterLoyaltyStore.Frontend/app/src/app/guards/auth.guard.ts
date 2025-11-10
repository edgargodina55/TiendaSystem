import { Injectable } from '@angular/core';
import { CanActivate, Router, UrlTree } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router) {}

  canActivate(): boolean | UrlTree {
    const token = localStorage.getItem('token');

    // Si hay token => permitir acceso
    if (token) {
      return true;
    }

    // Si no hay token => redirigir al login
    return this.router.parseUrl('/login');
  }
}
