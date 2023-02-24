import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GenresComponent } from 'src/app/genres/feature/genres/genres.component';
import { HallComponent } from 'src/app/halls/feature/hall/hall.component';
import { HallsComponent } from 'src/app/halls/feature/halls/halls.component';
import { MovieLanguagesComponent } from 'src/app/movieLanguages/feature/movie-languages/movie-languages.component';
import { MovieComponent } from 'src/app/movies/feature/movie/movie.component';
import { MoviesExternalComponent } from 'src/app/movies/feature/movies-external/movies-external.component';
import { MoviesComponent } from 'src/app/movies/feature/movies/movies.component';
import { ProductionCompaniesComponent } from 'src/app/productionCompanies/feature/production-companies/production-companies.component';
import { ProductionCountriesComponent } from 'src/app/productionCountries/feature/production-countries/production-countries.component';
import { RawQueryComponent } from 'src/app/rawQuery/feature/raw-query/raw-query.component';
import { ReservationComponent } from 'src/app/reservations/feature/reservation/reservation.component';
import { ReservationsComponent } from 'src/app/reservations/feature/reservations/reservations.component';
import { ScreeningComponent } from 'src/app/screenings/feature/screening/screening.component';
import { AdminGuard } from 'src/app/shared/guards/admin.guard';
import { StatisticsComponent } from 'src/app/statistics/feature/statistics/statistics.component';

const routes: Routes = [
  { path: "admin/movies", component: MoviesComponent, canActivate: [AdminGuard] },
  { path: "admin/movies/external", component: MoviesExternalComponent, canActivate: [AdminGuard] },
  { path: 'admin/movies/raw', component: RawQueryComponent },
  { path: "admin/movies/:id", component: MovieComponent },
  { path: "admin/halls/:id", component: HallComponent },
  { path: "admin/halls", component: HallsComponent },
  { path: "admin/screenings/:id", component: ScreeningComponent },
  { path: "admin/reservations", component: ReservationsComponent },
  { path: "admin/reservations/:id", component: ReservationComponent },
  { path: "admin/genres", component: GenresComponent },
  { path: "admin/productionCompanies", component: ProductionCompaniesComponent },
  { path: "admin/productionCountries", component: ProductionCountriesComponent },
  { path: "admin/movieLanguages", component: MovieLanguagesComponent },
  { path: "admin/statistics", component: StatisticsComponent },
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
export class AdminRoutingModule { }
