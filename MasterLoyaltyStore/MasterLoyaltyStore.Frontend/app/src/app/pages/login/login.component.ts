import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';   // 👈 solo Router

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  loading = false;
  errorMessage = '';

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {}

  onSubmit(): void {
    // Validations
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    this.loading = true;
    this.errorMessage = '';

    this.authService.login(this.loginForm.value).subscribe({
      next: (res) => {
        console.log('RESPUESTA DEL LOGIN 👉', res);

        if (res && res.success && res.data) {
          const token = res.data.token;
          const user = res.data.user;

          this.authService.storeSession(token,user);

          this.router.navigate(['/index']);
        } else {
          this.errorMessage = res?.message || 'No se pudo iniciar sesión';
        }

        this.loading = false;   // 👈 aquí sí
      },
      error: (err) => {
        console.log('ERROR LOGIN 👉', err);
        this.errorMessage = 'Credenciales Incorrectas';
        this.loading = false;   // 👈 aquí también
      }
    });

    // 👇 ESTE ya no, porque se ejecuta antes de que responda el backend
    // this.loading = false;
  }
}
