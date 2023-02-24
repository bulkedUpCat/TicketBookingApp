import { DatePipe } from '@angular/common';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { IMovie, IMovieModel, MovieFilter } from 'src/app/shared/models/movie';
import { MovieService } from '../../data-access/movie.service';
import { AddMovieComponent } from '../add-movie/add-movie.component';
import { EditMovieComponent } from '../edit-movie/edit-movie.component';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['id','title', 'description', 'dateReleased', 'budget', 'revenue', 'actions'];
  @ViewChild('paginator') paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<IMovie[]>;
  movies;

  constructor(private movieService: MovieService,
    private dialog: MatDialog) { }

  ngAfterViewInit(): void {

  }

  ngOnInit(): void {
    this.getMovies();
  }

  getMovies(){
    this.movieService.getMovies(new MovieFilter()).subscribe(m => {
      this.movies = m.movies;
      this.dataSource = new MatTableDataSource(this.movies);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    })
  }

  doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  onAddNew(){
    const dialogRef = this.dialog.open(AddMovieComponent, {
      width: '700px',
      height: '100%',
    });

    dialogRef.afterClosed().subscribe(m => {
      this.getMovies();
    });
  }

  onEditMovie(movie: IMovie){
    const dialogRef = this.dialog.open(EditMovieComponent, {
      width: '700px',
      height: '100%',
      data: {
        movie: movie
      }
    });

    dialogRef.afterClosed().subscribe(m => {
      this.getMovies();
    });
  }

  onDeleteMovie(id: string){
    this.movieService.deleteMovie(id).subscribe(m => {
      this.getMovies();
    });
  }
}
