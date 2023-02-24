export interface IScreeningModel{
  id: string;
  hallId: string;
  movieLanguageId: string;
  movieId: string;
  movieTitle: string;
  price: number;
  start: Date;
  reservations: string[];
}

export interface ICreateScreeningModel{
  hallId: string;
  movieId: string;
  price: number;
  start: Date;
}
