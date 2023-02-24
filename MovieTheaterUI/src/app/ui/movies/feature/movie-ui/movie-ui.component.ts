import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { MovieService } from 'src/app/movies/data-access/movie.service';
import { IMovie } from 'src/app/shared/models/movie';
import { IScreeningModel } from 'src/app/shared/models/screening';

@Component({
  selector: 'app-movie-ui',
  templateUrl: './movie-ui.component.html',
  styleUrls: ['./movie-ui.component.scss']
})
export class MovieUiComponent implements OnInit {
  movie: IMovie;
  sortedScreenings: IScreeningModel[];

  constructor(private route: ActivatedRoute,
    private movieService: MovieService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      let id = params.get('id')
      this.getMovieById(id);
    })
  }

  getMovieById(id: string){
    return this.movieService.getMovieById(id).subscribe(m => {
      this.movie = m;
      this.sortedScreenings = this.movie.screenings.sort((a,b) => a.start > b.start ? 1 : -1);
      console.log(m);
    })
  }

  onPlayMovie(){
    document.getElementById("play").classList.add("active-popup");
  }

  onCloseMovie(){
    document.getElementById("play").classList.remove("active-popup");
  }
}
