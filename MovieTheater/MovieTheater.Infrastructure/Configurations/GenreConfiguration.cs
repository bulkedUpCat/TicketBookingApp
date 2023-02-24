using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Configurations;

public class GenreConfiguration: IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(g => g.Id);

        builder
            .Property(g => g.Name)
            .HasMaxLength(40)
            .IsRequired();

        builder
            .HasMany(g => g.Movies)
            .WithMany(m => m.Genres);

        builder.ToTable("Genres");
    }
}