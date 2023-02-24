import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MovieService } from '../../data-access/movie.service';

@Component({
  selector: 'app-add-movie',
  templateUrl: './add-movie.component.html',
  styleUrls: ['./add-movie.component.scss']
})
export class AddMovieComponent implements OnInit {
  movieForm: FormGroup;

  constructor(private movieService: MovieService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<AddMovieComponent>) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.movieForm = this.fb.group({
      title: [null,[Validators.required]],
      description: [null, [Validators.required]],
      durationMinutes: [null,[Validators.required]],
      dateReleased: [null,[Validators.required]],
      budget: [null, [Validators.required]],
      IMDbRating: [null, [Validators.required]],
      revenue: [null, [Validators.required]],
      poster: [null, [Validators.required]]
    });
  }

  onSubmit(){
    console.log(this.movieForm.value);
    if (this.movieForm.invalid){
      return;
    }

    const movie = this.movieForm.value;

    this.movieService.createMovie(movie).subscribe(m => {
      this.dialogRef.close();
    });
  }
}
