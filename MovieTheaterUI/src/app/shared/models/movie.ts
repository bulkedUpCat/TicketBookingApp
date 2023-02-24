import { IGenre } from "./genre";
import { IMovieDirectorModel } from "./movieDirector";
import { IMovieLanguageModel } from "./movieLanguage";
import { IProductionCompany } from "./productionCompany";
import { IProductionCountryModel } from "./productionCountry";
import { IScreeningModel } from "./screening";

export interface IMovieModel{
  movies: IMovie[];
}

export interface IMovie{
  id: string;
  title: string;
  description: string;
  durationMinutes: number;
  dateReleased: Date;
  budget: number;
  imDbRating: number;
  revenue: number;
  poster: string;
  productionCompany: IProductionCompany;
  movieDirector: IMovieDirectorModel;
  screenings: IScreeningModel[];
  countries: IProductionCountryModel[];
  languages: IMovieLanguageModel[];
  genres: IGenre[];
}

export interface ICreateMovie{
  title: string;
  description: string;
  durationMinutes: number;
  dateReleased: Date;
  budget: number;
  imdbRating: number;
  revenue: number;
  poster: string;
}

export interface IEditMovie{
  title: string;
  description: string;
  durationMinutes: number;
  dateReleased: Date;
  budget: number;
  imDbRating: number;
  revenue: number;
  poster: string;
  genres: string[];
  countries: string[];
  languages: string[];
}

export interface IMovieFilter{
  title: string;
  genres: string[];
  runtime: number[];
  companies: string[];
  countries: string[];
  sortingOption: string;
}

export class MovieFilter implements IMovieFilter{
  title: string;
  genres: string[] = [];
  runtime: number[] = [];
  companies: string[] = [];
  countries: string[] = [];
  sortingOption: string;
}
