import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NotifierService } from 'src/app/shared/services/notifier.service';
import { AuthService } from '../../data-access/auth.service';

@Component({
  selector: 'app-user-signup',
  templateUrl: './user-signup.component.html',
  styleUrls: ['./user-signup.component.scss']
})
export class UserSignupComponent implements OnInit {
  signupForm: FormGroup;
  submitted: boolean;
  constructor(private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private notifier: NotifierService) { }

  ngOnInit(): void {
    this.createForm()
  }

  createForm(){
    this.signupForm = this.fb.group({
      userName: [null, [Validators.required]],
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
      confirmPassword: [null, [Validators.required]]
    })
  }

  get userName(){
    return this.signupForm.get('userName');
  }

  get email(){
    return this.signupForm.get('email');
  }

  get password(){
    return this.signupForm.get('password');
  }

  get confirmPassword(){
    return this.signupForm.get('confirmPassword');
  }

  onSignup(){
    this.submitted = true;

    if (!this.signupForm.valid){
      console.log('invalid');
      return;
    }

    this.authService.signUp(this.signupForm.value).subscribe(user => {
      console.log(user);
      this.router.navigateByUrl('/auth/login');
    }, err => {
      this.notifier.showNotification(err.error, 'ERROR');
    })
  }
}
