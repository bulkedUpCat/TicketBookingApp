using AutoMapper;
using MovieTheater.Application.Halls.Commands.CreateHall;
using MovieTheater.Application.Shared.Hall;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Profiles;

public class HallProfile: Profile
{
    public HallProfile()
    {
        CreateMap<Hall, HallModel>()
            .ForMember(dest => dest.SeatsNumber, src => src.MapFrom(opt => opt.Seats.Count))
            .ForMember(dest => dest.RowsNumber, src => src.MapFrom(opt => opt.Seats.GroupBy(s => s.Row).Count()));

        CreateMap<CreateHallCommand, Hall>();
    }
}