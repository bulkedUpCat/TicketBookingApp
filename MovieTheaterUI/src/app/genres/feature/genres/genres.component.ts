import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IGenre } from 'src/app/shared/models/genre';
import { GenreService } from '../../data-access/genre.service';
import { AddGenreComponent } from '../add-genre/add-genre.component';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.scss']
})
export class GenresComponent implements OnInit {
  genres: IGenre[];
  constructor(private genreService: GenreService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getAllGenres();
  }

  getAllGenres(){
    this.genreService.getAllGenres().subscribe(g => {
      this.genres = g;
      console.log(g);
    })
  }

  onAddGenre(){
    const dialogRef = this.dialog.open(AddGenreComponent, {
      width: '400px'
    })

    dialogRef.afterClosed().subscribe(m => {
      this.getAllGenres();
    });
  }
}
