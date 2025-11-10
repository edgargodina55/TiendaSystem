import { Component, OnInit } from '@angular/core';
import { UserRole } from 'src/app/constants/enums/userRole.enum';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  user: any = null;
  roleName = '';
  roleId:number|null = null

  constructor(private router:Router,private authService: AuthService){}

  ngOnInit(): void {
    const userStorage = localStorage.getItem('user');
    if (userStorage) {
      this.user = JSON.parse(userStorage);
      this.roleName = this.user.roleName;
      this.roleId = this.user.roleId;
    }
  }

  isAdmin(): boolean {
    return this.roleId === UserRole.Admin;
  }

  isCustomer(): boolean {
    return this.roleId === UserRole.Customer;
  }

  logout():void{
    this.authService.logout();
    this.router.navigate(['/login']); // y te saca

  }
}
