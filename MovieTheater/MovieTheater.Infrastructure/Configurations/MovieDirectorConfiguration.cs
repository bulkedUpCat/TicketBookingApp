using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Configurations;

public class MovieDirectorConfiguration: IEntityTypeConfiguration<MovieDirector>
{
    public void Configure(EntityTypeBuilder<MovieDirector> builder)
    {
        builder.HasKey(md => md.Id);

        builder
            .Property(md => md.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(md => md.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasMany(md => md.Movies)
            .WithOne(m => m.MovieDirector);

        builder.ToTable("MovieDirectors");
    }
}