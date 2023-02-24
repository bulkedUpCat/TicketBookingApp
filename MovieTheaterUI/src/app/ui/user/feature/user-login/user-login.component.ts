import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NotifierService } from 'src/app/shared/services/notifier.service';
import { AuthService } from '../../data-access/auth.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent implements OnInit {
  loginForm: FormGroup;
  submitted: boolean;
  constructor(private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private notifier: NotifierService) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.loginForm = this.fb.group({
      email: [null, [Validators.required]],
      password: [null, [Validators.required]]
    });
  }

  get email(){
    return this.loginForm.get('email');
  }

  get password(){
    return this.loginForm.get('password');
  }

  onLogin(){
    this.submitted = true;

    if (!this.loginForm.valid){
      return;
    }

    this.authService.logIn(this.loginForm.value).subscribe(u => {
      console.log(u);
      localStorage.setItem('auth_token', u?.token);
      this.router.navigateByUrl("");
    }, err => {
      this.notifier.showNotification(err.error, 'ERROR');
    });
  }
}
