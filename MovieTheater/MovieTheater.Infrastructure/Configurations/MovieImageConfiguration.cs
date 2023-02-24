using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Configurations;

public class MovieImageConfiguration: IEntityTypeConfiguration<MovieImage>
{
    public void Configure(EntityTypeBuilder<MovieImage> builder)
    {
        builder.HasKey(mi => mi.Id);

        builder
            .Property(mi => mi.Path)
            .HasMaxLength(300)
            .IsRequired();

        builder
            .HasOne(mi => mi.Movie)
            .WithMany(m => m.MovieImages);

        builder.ToTable("MovieImages");
    }
}