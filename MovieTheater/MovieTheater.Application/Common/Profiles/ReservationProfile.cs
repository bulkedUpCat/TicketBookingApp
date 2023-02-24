using AutoMapper;
using MovieTheater.Application.Reservations.Commands.CreateReservation;
using MovieTheater.Application.Shared.Reservation;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Profiles;

public class ReservationProfile: Profile
{
    public ReservationProfile()
    {
        CreateMap<Reservation, ReservationModel>()
            .ForMember(dest => dest.ReservedSeats, src => src.MapFrom(opt => opt.ReservedSeats.Select(rs => rs.Id)));

        CreateMap<CreateReservationCommand, Reservation>()
            .ForMember(dest => dest.UserId, src => src.MapFrom(opt => opt.UserId.ToString()));
    }
}