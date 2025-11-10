import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup,Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  loading =false;
  errorMessage = '';

  constructor(private fb:FormBuilder,private authService:AuthService) {
    this.loginForm = this.fb.group({
      email: ['',[Validators.required,Validators.email]],
      password: ['',[Validators.required]]
    })
   }

   onSubmit(){
    //Validations
    if(this.loginForm.invalid){
      this.loginForm.markAllAsTouched();
      return;
    }
    
    this.loading = true;
    this.errorMessage = ''


    //Aqui tengo llamar a servicio
    this.authService.login(this.loginForm.value).subscribe({
      next: (res) => {
        //Guardar token en localStorage
        this.loading = false;
      },
      error: (err) =>{
        this.errorMessage = 'Credenciales Incorrectas'
        this.loading = false;
      }
    })

    this.loading= false;

   }

  ngOnInit(): void {
  }

}
