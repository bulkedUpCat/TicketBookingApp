using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Configurations;

public class ReservationConfiguration: IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(r => r.Id);

        builder
            .HasOne(r => r.Screening)
            .WithMany(s => s.Reservations);

        builder
            .HasMany(r => r.ReservedSeats)
            .WithOne(rs => rs.Reservation);

        builder.HasQueryFilter(r => r.ValidTo > DateTime.UtcNow || r.Paid);

        builder.ToTable("Reservations");
    }
}