using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Configurations;

public class MovieLanguageConfiguration: IEntityTypeConfiguration<MovieLanguage>
{
    public void Configure(EntityTypeBuilder<MovieLanguage> builder)
    {
        builder.HasKey(ml => ml.Id);

        builder
            .Property(ml => ml.Name)
            .IsRequired();

        builder
            .HasMany(ml => ml.Movies)
            .WithMany(m => m.MovieLanguages);

        builder
            .HasMany(ml => ml.Screenings)
            .WithOne(s => s.MovieLanguage);

        builder.ToTable("MovieLanguages");
    }
}