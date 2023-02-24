
export interface ISeatModel{
  id: string;
  row: number;
  number: number;
  priceOffset: number;
  hallId: string;
  reservedScreenings: string[];
  status: ISeatStatus;
  reservations: string[];
}

export enum ISeatStatus{
  Free = 0,
  Chosen,
  Occupied
}
