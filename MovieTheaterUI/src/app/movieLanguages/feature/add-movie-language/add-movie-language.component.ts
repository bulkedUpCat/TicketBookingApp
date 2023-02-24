import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { AddGenreComponent } from 'src/app/genres/feature/add-genre/add-genre.component';
import { MovieLanguageService } from '../../data-access/movie-language.service';

@Component({
  selector: 'app-add-movie-language',
  templateUrl: './add-movie-language.component.html',
  styleUrls: ['./add-movie-language.component.scss']
})
export class AddMovieLanguageComponent implements OnInit {
  movieLanguageForm: FormGroup;
  constructor(private fb: FormBuilder,
    private movieLanguageService: MovieLanguageService,
    private dialogRef: MatDialogRef<AddGenreComponent>) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.movieLanguageForm = this.fb.group({
      name: [null, [Validators.required]]
    });
  }

  onSubmit(){
    if (!this.movieLanguageForm.valid){
      return;
    }

    this.movieLanguageService.createMovieLanguage(this.movieLanguageForm.value).subscribe(g => {
      this.dialogRef.close();
    }, err => {
      console.log(err);
    });
  }
}
