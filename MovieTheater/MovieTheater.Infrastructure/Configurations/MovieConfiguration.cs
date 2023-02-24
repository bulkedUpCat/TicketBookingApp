using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Configurations;

public class MovieConfiguration: IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(m => m.Id);

        builder
            .Property(m => m.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(m => m.Description)
            .HasMaxLength(1000)
            .IsRequired();

        builder
            .Property(m => m.DurationMinutes)
            .IsRequired();

        builder
            .HasOne(m => m.MovieDirector)
            .WithMany(md => md.Movies);

        builder
            .HasOne(m => m.ProductionCompany)
            .WithMany(pc => pc.Movies);
        
        builder
            .HasMany(m => m.Genres)
            .WithMany(g => g.Movies);

        builder
            .HasMany(m => m.Screenings)
            .WithOne(s => s.Movie);

        builder
            .HasMany(m => m.ProductionCountries)
            .WithMany(pc => pc.Movies);

        builder
            .HasMany(m => m.MovieLanguages)
            .WithMany(ml => ml.Movies);

        builder
            .HasMany(m => m.MovieImages)
            .WithOne(mi => mi.Movie);

        builder.ToTable("Movies");
    }
}