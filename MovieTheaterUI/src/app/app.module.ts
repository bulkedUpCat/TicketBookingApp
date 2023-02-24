import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatNativeDateModule } from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { SwiperModule } from 'swiper/angular';
import { JwtModule } from '@auth0/angular-jwt';
import {MatSnackBarModule} from '@angular/material/snack-bar';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SeatDisplayComponent } from './seats/feature/seat-display/seat-display.component';
import { HallsComponent } from './halls/feature/halls/halls.component';
import { AddHallComponent } from './halls/feature/add-hall/add-hall.component';
import { HallComponent } from './halls/feature/hall/hall.component';
import { ScreeningsComponent } from './screenings/feature/screenings/screenings.component';
import { AddScreeningComponent } from './screenings/feature/add-screening/add-screening.component';
import { MoviesComponent } from './movies/feature/movies/movies.component';
import { AddMovieComponent } from './movies/feature/add-movie/add-movie.component';
import { MovieComponent } from './movies/feature/movie/movie.component';
import { ScreeningComponent } from './screenings/feature/screening/screening.component';
import { ReservationsComponent } from './reservations/feature/reservations/reservations.component';
import { ReservationComponent } from './reservations/feature/reservation/reservation.component';
import { NavBarComponent } from './navigation/feature/nav-bar/nav-bar.component';
import { MoviesUiComponent } from './ui/movies/feature/movies-ui/movies-ui.component';
import { AdminRoutingModule } from './routing/admin-routing/admin-routing.module';
import { UiRoutingModule } from './routing/ui-routing/ui-routing.module';
import { HomeUiComponent } from './ui/movies/feature/home-ui/home-ui.component';
import { ScrollBarUiComponent } from './ui/movies/feature/scroll-bar-ui/scroll-bar-ui.component';
import { MovieUiComponent } from './ui/movies/feature/movie-ui/movie-ui.component';
import { EditMovieComponent } from './movies/feature/edit-movie/edit-movie.component';
import { UserLoginComponent } from './ui/user/feature/user-login/user-login.component';
import { NavbarUiComponent } from './ui/movies/feature/navbar-ui/navbar-ui.component';
import { UserSignupComponent } from './ui/user/feature/user-signup/user-signup.component';
import { GenresComponent } from './genres/feature/genres/genres.component';
import { AddGenreComponent } from './genres/feature/add-genre/add-genre.component';
import { MovieAddGenreComponent } from './movies/feature/movie-add-genre/movie-add-genre.component';
import { ScreeningUiComponent } from './ui/screenings/feature/screening-ui/screening-ui.component';
import { SeatsUiComponent } from './ui/seats/feature/seats-ui/seats-ui.component';
import { AddReservationUiComponent } from './ui/reservations/feature/add-reservation-ui/add-reservation-ui.component';
import { TicketUiComponent } from './ui/tickets/feature/ticket-ui/ticket-ui.component';
import { UserPageUiComponent } from './ui/user/feature/user-page-ui/user-page-ui.component';
import { ProductionCompaniesComponent } from './productionCompanies/feature/production-companies/production-companies.component';
import { MovieAddProductionCompanyComponent } from './movies/feature/movie-add-production-company/movie-add-production-company.component';
import { MovieAddProductionCountryComponent } from './movies/feature/movie-add-production-country/movie-add-production-country.component';
import { ProductionCountriesComponent } from './productionCountries/feature/production-countries/production-countries.component';
import { AddProductionCountryComponent } from './productionCountries/feature/add-production-country/add-production-country.component';
import { AddProductionCompanyComponent } from './productionCompanies/feature/add-production-company/add-production-company.component';
import { MovieLanguagesComponent } from './movieLanguages/feature/movie-languages/movie-languages.component';
import { AddMovieLanguageComponent } from './movieLanguages/feature/add-movie-language/add-movie-language.component';
import { MovieAddLanguageComponent } from './movies/feature/movie-add-language/movie-add-language.component';
import { MovieAddScreeeningComponent } from './movies/feature/movie-add-screeening/movie-add-screeening.component';
import { MovieAddMovieDirectorComponent } from './movies/feature/movie-add-movie-director/movie-add-movie-director.component';
import { NotifierComponent } from './notifiers/notifier/notifier.component';
import { MoviesExternalComponent } from './movies/feature/movies-external/movies-external.component';
import { MovieExternalDetailComponent } from './movies/movie-external-detail/movie-external-detail.component';
import { StatisticsComponent } from './statistics/feature/statistics/statistics.component';
import { RawQueryComponent } from './rawQuery/feature/raw-query/raw-query.component';
import { SendReservationComponent } from './reservations/feature/send-reservation/send-reservation.component';

export function tokenGetter() {
  return localStorage.getItem("auth_token");
}

@NgModule({
  declarations: [
    AppComponent,
    SeatDisplayComponent,
    HallsComponent,
    AddHallComponent,
    HallComponent,
    ScreeningsComponent,
    AddScreeningComponent,
    MoviesComponent,
    AddMovieComponent,
    MovieComponent,
    ScreeningComponent,
    ReservationsComponent,
    ReservationComponent,
    NavBarComponent,
    MoviesUiComponent,
    HomeUiComponent,
    ScrollBarUiComponent,
    MovieUiComponent,
    EditMovieComponent,
    UserLoginComponent,
    NavbarUiComponent,
    UserSignupComponent,
    GenresComponent,
    AddGenreComponent,
    MovieAddGenreComponent,
    ScreeningUiComponent,
    SeatsUiComponent,
    AddReservationUiComponent,
    TicketUiComponent,
    UserPageUiComponent,
    ProductionCompaniesComponent,
    MovieAddProductionCompanyComponent,
    MovieAddProductionCountryComponent,
    ProductionCountriesComponent,
    AddProductionCountryComponent,
    AddProductionCompanyComponent,
    MovieLanguagesComponent,
    AddMovieLanguageComponent,
    MovieAddLanguageComponent,
    MovieAddScreeeningComponent,
    MovieAddMovieDirectorComponent,
    NotifierComponent,
    MoviesExternalComponent,
    MovieExternalDetailComponent,
    StatisticsComponent,
    RawQueryComponent,
    SendReservationComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AdminRoutingModule,
    UiRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatFormFieldModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    NgxMaterialTimepickerModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatButtonModule,
    MatCardModule,
    MatSelectModule,
    MatSnackBarModule,
    SwiperModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:7159'],
        disallowedRoutes: []
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
