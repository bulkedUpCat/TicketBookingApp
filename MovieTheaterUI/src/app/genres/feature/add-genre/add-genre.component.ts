import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { GenreService } from '../../data-access/genre.service';

@Component({
  selector: 'app-add-genre',
  templateUrl: './add-genre.component.html',
  styleUrls: ['./add-genre.component.scss']
})
export class AddGenreComponent implements OnInit {
  genreForm: FormGroup;
  constructor(private fb: FormBuilder,
    private genreService: GenreService,
    private dialogRef: MatDialogRef<AddGenreComponent>) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.genreForm = this.fb.group({
      name: [null, [Validators.required]]
    });
  }

  onSubmit(){
    if (!this.genreForm.valid){
      return;
    }

    this.genreService.createGenre(this.genreForm.value).subscribe(g => {
      this.dialogRef.close();
    }, err => {
      console.log(err);
    });
  }
}
