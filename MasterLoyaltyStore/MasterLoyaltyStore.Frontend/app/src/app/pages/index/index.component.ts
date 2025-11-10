import { Component, OnInit } from '@angular/core';
import { UserRole } from 'src/app/constants/enums/userRole.enum';
@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  user: any = null;
  roleName = '';
  roleId : number | null = null;

  ngOnInit(): void {

    const userStorage = localStorage.getItem('user');
    if(userStorage){
      this.user = JSON.parse(userStorage);
      this.roleName = this.user.roleName;
      this.user.roleId;
    }
  }

  isAdmin(): boolean{
      return this.roleName === "Admin" || this.roleId === UserRole.Admin;
  }

  isCustomer(): boolean{
    return this.roleName === "Customer" || this.roleId === UserRole.Customer;
  }

}
