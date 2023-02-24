using AutoMapper;
using MovieTheater.Application.Shared.Seat;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Profiles;

public class SeatProfile: Profile
{
    public SeatProfile()
    {
        CreateMap<Seat, SeatModel>()
            .ForMember(dest => dest.ReservedScreenings,
                src => src.MapFrom(opt => opt.ReservedSeats.Select(rs => rs.Reservation.ScreeningId)))
            .ForMember(dest => dest.Reservations,
                src => src.MapFrom(opt => opt.ReservedSeats.Select(rs => rs.ReservationId)));
    }
}