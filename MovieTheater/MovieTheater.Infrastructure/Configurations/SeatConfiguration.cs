using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Application.Shared.Seat;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Configurations;

public class SeatConfiguration: IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.HasKey(s => s.Id);

        builder
            .Property(s => s.Row)
            .IsRequired();

        builder
            .Property(s => s.Number)
            .IsRequired();

        builder
            .HasOne(s => s.Hall)
            .WithMany(h => h.Seats);

        builder
            .HasMany(s => s.ReservedSeats)
            .WithOne(rs => rs.Seat);

        builder.ToTable("Seats");
    }
}