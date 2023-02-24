import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/ui/user/data-access/auth.service';

@Component({
  selector: 'app-navbar-ui',
  templateUrl: './navbar-ui.component.html',
  styleUrls: ['./navbar-ui.component.scss']
})
export class NavbarUiComponent implements OnInit {
  userLoggedIn: boolean;
  isManager: boolean;
  isAdmin: boolean;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.isLoggedIn.subscribe(u => {
      this.userLoggedIn = u;
    })
  }

  onLogout(){
    this.authService.logOut();
  }
}
