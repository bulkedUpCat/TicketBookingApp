using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieTheater.Application.Common.Interfaces;
using MovieTheater.Domain.Entities;
using MovieTheater.Infrastructure.Configurations;

namespace MovieTheater.Infrastructure.Data.Contexts;

public class MovieTheaterDbContext: IdentityDbContext<User>, IMovieTheaterDbContext
{
    public MovieTheaterDbContext(DbContextOptions<MovieTheaterDbContext> options): base(options){}

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Screening> Screenings { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservedSeat> ReservedSeats { get; set; }
    public DbSet<MovieDirector> MovieDirectors { get; set; }
    public DbSet<MovieLanguage> MovieLanguages { get; set; }
    public DbSet<ProductionCountry> ProductionCountries { get; set; }
    public DbSet<MovieImage> MovieImages { get; set; }
    public DbSet<ProductionCompany> ProductionCompanies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieConfiguration).Assembly);
        IdentityDataInitializer.SeedData(modelBuilder);

        base.OnModelCreating(modelBuilder);
        RenameAspNetIdentityTables(modelBuilder);
    }

    private void RenameAspNetIdentityTables(ModelBuilder builder)
    {
        string schema = "dbo";

        builder.Entity<User>(entity =>
        {
            entity.ToTable("Users", schema);
        });

        builder.Entity<IdentityRole>(entity =>
        {
            entity.ToTable("Roles", schema);
        });

        builder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.ToTable("UserClaims", schema);
        });
        
        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.ToTable("UserLogins", schema);
        });

        builder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            entity.ToTable("RoleClaims", schema);
        });

        builder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.ToTable("UserRoles", schema);
        });

        builder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.ToTable("UserTokens", schema);
        });
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);
    }
}