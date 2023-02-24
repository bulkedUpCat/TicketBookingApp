using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Configurations;

public class ReservedSeatConfiguration: IEntityTypeConfiguration<ReservedSeat>
{
    public void Configure(EntityTypeBuilder<ReservedSeat> builder)
    {
        builder.HasKey(rs => rs.Id);

        builder
            .HasOne(rs => rs.Seat)
            .WithMany(s => s.ReservedSeats);

        builder
            .HasOne(rs => rs.Reservation)
            .WithMany(r => r.ReservedSeats);

        builder.ToTable("ReservedSeats");
    }
}