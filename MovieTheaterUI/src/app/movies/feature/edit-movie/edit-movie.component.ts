import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IMovie } from 'src/app/shared/models/movie';
import { MovieService } from '../../data-access/movie.service';

@Component({
  selector: 'app-edit-movie',
  templateUrl: './edit-movie.component.html',
  styleUrls: ['./edit-movie.component.scss']
})
export class EditMovieComponent implements OnInit {
  movie: IMovie;
  movieForm: FormGroup;

  constructor(private movieService: MovieService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<EditMovieComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.movie = this.data.movie;
    console.log(this.movie);
    this.createForm();
  }

  createForm(){
    this.movieForm = this.fb.group({
      title: [this.movie.title,[Validators.required]],
      description: [this.movie.description, [Validators.required]],
      durationMinutes: [this.movie.durationMinutes,[Validators.required]],
      dateReleased: [this.movie.dateReleased,[Validators.required]],
      budget: [this.movie.budget, [Validators.required]],
      imDbRating: [this.movie.imDbRating, [Validators.required]],
      revenue: [this.movie.revenue, [Validators.required]],
      poster: [this.movie.poster, [Validators.required]]
    });
  }

  onSubmit(){
    console.log(this.movieForm.value);
    if (this.movieForm.invalid){
      return;
    }

    const movie = this.movieForm.value;

    this.movieService.editMovie(this.movie.id, movie).subscribe(m => {
      this.dialogRef.close();
    });
  }
}
