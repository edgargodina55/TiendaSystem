import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  showForm = false;
  userForm: FormGroup;
  users: any[] = [];
  userTypes = [
    { id: 1, name: 'Admin' },
    { id: 2, name: 'Customer' }
  ];

  constructor(private fb: FormBuilder, private userService: UserService) {
    this.userForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      userName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      address: [''],
      userTypeId: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadUsers();
  }

  toggleForm(): void {
    this.showForm = !this.showForm;
    this.userForm.reset();
  }

  loadUsers(): void {
    this.userService.getAll().subscribe({
      next: (res) => {
        this.users = res.data || [];
      },
      error: (err) => {
        console.error('Error cargando usuarios:', err);
      }
    });
  }

  onSubmit(): void {
    if (this.userForm.invalid) return;

    this.userService.create(this.userForm.value).subscribe({
      next: (res) => {
        this.loadUsers();
        this.toggleForm();
      },
      error: (err) => console.error(err)
    });
  }

  editUser(user: any): void {
    this.showForm = true;
    this.userForm.patchValue(user);
  }

  deleteUser(id: number): void {
    if (confirm('¿Seguro que deseas eliminar este usuario?')) {
      this.userService.delete(id).subscribe({
        next: () => this.loadUsers(),
        error: (err) => console.error(err)
      });
    }
  }
}
