import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable, of, tap } from 'rxjs';
import { IUserLoginModel, IUserSignupModel } from 'src/app/shared/models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public loggedIn = new BehaviorSubject<boolean>(!!localStorage.getItem('auth_token'));
  public claims = new BehaviorSubject<string[]>(null);

  constructor(private http: HttpClient,
    private router: Router,
    private jwtHelper: JwtHelperService) {
      const token = localStorage.getItem('auth_token');
      let payload: string;

      if (token && !this.jwtHelper.isTokenExpired(token)){
        payload = token.split('.')[1];
        payload = window.atob(payload);
        payload = JSON.parse(payload);

        this.claims.next(payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']);
      }
    }

  get isLoggedIn(){
    const token = localStorage.getItem('auth_token');

    if (token && this.jwtHelper.isTokenExpired(token)){
      this.loggedIn.next(false);
      this.claims.next([]);
    }

    return this.loggedIn.asObservable();
  }

  getUserInfo(){
    const token = localStorage.getItem('auth_token');
    let payload;

    if (token && !this.jwtHelper.isTokenExpired(token)){
      payload = token.split('.')[1];
      payload = window.atob(payload);
      payload = JSON.parse(payload);

      this.claims.next(payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']);
      return of(payload);
    }
    return of(null);
  }

  logIn(user: IUserLoginModel) : Observable<any>{
    return this.http.post<IUserLoginModel>(`${environment.apiUrl}/auth/login`,user)
      .pipe(tap(user => {
        if (user.token){
          localStorage.setItem("auth_token",user.token);

          const token = localStorage.getItem('auth_token');
          let payload;

          payload = token.split('.')[1];
          payload = window.atob(payload);
          payload = JSON.parse(payload);
          this.claims.next(payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']);
          this.loggedIn.next(true);
        }
      }));
  }

  signUp(user: IUserSignupModel){
    return this.http.post<IUserSignupModel>(`${environment.apiUrl}/auth/signup`,user);
  }

  logOut(){
    this.loggedIn.next(false);
    localStorage.removeItem("auth_token");
    this.claims.next([]);
    this.router.navigate(['/auth/login']);
  }
}
