using AutoMapper;
using MovieTheater.Application.Shared.ReservedSeat;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Profiles;

public class ReservedSeatProfile: Profile
{
    public ReservedSeatProfile()
    {
        CreateMap<ReservedSeat, ReservedSeatModel>()
            .ForMember(dest => dest.Row, src => src.MapFrom(opt => opt.Seat.Row))
            .ForMember(dest => dest.Number, src => src.MapFrom(opt => opt.Seat.Number));
    }
}