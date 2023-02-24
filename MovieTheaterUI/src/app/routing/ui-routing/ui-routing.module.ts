import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RawQueryComponent } from 'src/app/rawQuery/feature/raw-query/raw-query.component';
import { AuthGuard } from 'src/app/shared/guards/auth.guard';
import { HomeUiComponent } from 'src/app/ui/movies/feature/home-ui/home-ui.component';
import { MovieUiComponent } from 'src/app/ui/movies/feature/movie-ui/movie-ui.component';
import { MoviesUiComponent } from 'src/app/ui/movies/feature/movies-ui/movies-ui.component';
import { AddReservationUiComponent } from 'src/app/ui/reservations/feature/add-reservation-ui/add-reservation-ui.component';
import { ScreeningUiComponent } from 'src/app/ui/screenings/feature/screening-ui/screening-ui.component';
import { UserLoginComponent } from 'src/app/ui/user/feature/user-login/user-login.component';
import { UserPageUiComponent } from 'src/app/ui/user/feature/user-page-ui/user-page-ui.component';
import { UserSignupComponent } from 'src/app/ui/user/feature/user-signup/user-signup.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: HomeUiComponent },
  { path: 'movies', component: MoviesUiComponent},
  { path: 'movies/:id', component: MovieUiComponent },
  { path: 'auth/login', component: UserLoginComponent },
  { path: 'auth/signup', component: UserSignupComponent },
  { path: 'movies/:id/screenings/:id', component: ScreeningUiComponent, canActivate: [AuthGuard]},
  { path: 'reservations/:screeningId', component: AddReservationUiComponent, canActivate: [AuthGuard] },
  { path: 'home', component: UserPageUiComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: ''}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class UiRoutingModule { }
