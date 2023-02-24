using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Configurations;

public class HallConfiguration: IEntityTypeConfiguration<Hall>
{
    public void Configure(EntityTypeBuilder<Hall> builder)
    {
        builder.HasKey(h => h.Id);

        builder
            .Property(h => h.Name)
            .HasMaxLength(40)
            .IsRequired();

        builder
            .HasMany(h => h.Seats)
            .WithOne(s => s.Hall);

        builder
            .HasMany(h => h.Screenings)
            .WithOne(s => s.Hall);

        builder.ToTable("Halls");
    }
}