using Microsoft.EntityFrameworkCore;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Common.Interfaces;

public interface IMovieTheaterDbContext
{
    DbSet<Movie> Movies { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Hall> Halls { get; set; }
    DbSet<Screening> Screenings { get; set; }
    DbSet<Seat> Seats { get; set; }
    DbSet<Reservation> Reservations { get; set; }
    DbSet<ReservedSeat> ReservedSeats { get; set; }
    DbSet<MovieDirector> MovieDirectors { get; set; }
    DbSet<MovieLanguage> MovieLanguages { get; set; }
    DbSet<ProductionCountry> ProductionCountries { get; set; }
    DbSet<MovieImage> MovieImages { get; set; }
    DbSet<ProductionCompany> ProductionCompanies { get; set; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}