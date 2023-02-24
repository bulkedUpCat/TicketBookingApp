using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Configurations;

public class ScreeningConfiguration: IEntityTypeConfiguration<Screening>
{
    public void Configure(EntityTypeBuilder<Screening> builder)
    {
        builder.HasKey(s => s.Id);

        builder
            .Property(s => s.Start)
            .IsRequired();
        
        builder
            .Property(s => s.Price)
            .IsRequired();

        builder
            .HasOne(s => s.Movie)
            .WithMany(m => m.Screenings);

        builder
            .HasOne(s => s.Hall)
            .WithMany(h => h.Screenings);

        builder
            .HasMany(s => s.Reservations)
            .WithOne(r => r.Screening);

        builder
            .HasOne(s => s.MovieLanguage)
            .WithMany(ml => ml.Screenings);
        
        builder.HasQueryFilter(s => s.Start > DateTime.UtcNow);

        builder.ToTable("Screenings");
    }
}