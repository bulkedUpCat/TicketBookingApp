import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/movies/data-access/movie.service';
import { IMovieModel } from 'src/app/shared/models/movie';
import SwiperCore, { SwiperOptions, Keyboard, Pagination, Navigation, Virtual } from 'swiper';

SwiperCore.use([Keyboard, Pagination, Navigation, Virtual]);

@Component({
  selector: 'app-home-ui',
  templateUrl: './home-ui.component.html',
  styleUrls: ['./home-ui.component.scss']
})
export class HomeUiComponent implements OnInit {
  top3movies: IMovieModel[];
  comingOutThisWeekMovies: IMovieModel[];
  comingSoonMovies: IMovieModel[];

  config: SwiperOptions = {
    loop: true,
    slidesPerView: 1,
    autoplay: {
      delay: 1000,
      disableOnInteraction: false
    },
    spaceBetween: 50,
    scrollbar: { draggable: true },
  };

  configComing: SwiperOptions = {
    spaceBetween: 20,
    loop: true,
    autoplay: {
        delay: 2000,
        disableOnInteraction: false,
    },
    centeredSlides: true,
    breakpoints: {
        0: {
            slidesPerView: 2,
        },
        568: {
            slidesPerView: 3,
        },
        768: {
            slidesPerView: 4,
        },
        968: {
            slidesPerView: 5,
        }
    }
  };

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.getTop3Movies();
    this.getComingSoonMovies();
  }

  onSwiper(swiper) {
    console.log(swiper);
  }

  onSlideChange() {
    console.log('slide change');
  }

  getTop3Movies(){
    this.movieService.getTop3Movies().subscribe(m => {
      this.top3movies = m;
      this.comingOutThisWeekMovies = m;
    }, err => {
      console.log(err);
    });
  }

  getComingSoonMovies(){
    this.movieService.getComingSoonMovies().subscribe(m => {
      this.comingSoonMovies = m;
    }, err => {
      console.log(err);
    })
  }
}
