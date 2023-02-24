import { ISeatModel } from "./seat";

export interface IHall{
  name: string;
  seatsNumber: number;
  seatsInRow: number;
  seatPrice: number;
}

export interface IHallModel{
  id: string;
  name: string;
  seats: ISeatModel[];
  seatsNumber: number;
  rowsNumber: number;
}
