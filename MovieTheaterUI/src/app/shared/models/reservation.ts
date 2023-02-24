export interface IReservationModel{
  id: string;
  userId: string;
  screeningId: string;
  paid: boolean;
  reservedSeats: string[];
}

export interface ICreateReservationModel{
  userId: string;
  screeningId: string;
  seatIds: string[];
}

export class CreateReservationModel implements ICreateReservationModel{
  userId: string;
  screeningId: string;
  seatIds: string[];
}

export enum ReservationStatus{
  active,
  canceled,
  paid
}
