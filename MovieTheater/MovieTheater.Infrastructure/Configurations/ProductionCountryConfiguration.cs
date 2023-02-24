using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Configurations;

public class ProductionCountryConfiguration: IEntityTypeConfiguration<ProductionCountry>
{
    public void Configure(EntityTypeBuilder<ProductionCountry> builder)
    {
        builder.HasKey(pc => pc.Id);

        builder
            .Property(pc => pc.Name)
            .IsRequired();

        builder
            .HasMany(pc => pc.Movies)
            .WithMany(m => m.ProductionCountries);

        builder.ToTable("ProductionCountries");
    }
}