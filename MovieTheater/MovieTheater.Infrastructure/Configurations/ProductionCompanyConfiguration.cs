using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Configurations;

public class ProductionCompanyConfiguration: IEntityTypeConfiguration<ProductionCompany>
{
    public void Configure(EntityTypeBuilder<ProductionCompany> builder)
    {
        builder.HasKey(pc => pc.Id);

        builder
            .Property(pc => pc.Name)
            .IsRequired();

        builder
            .HasMany(pc => pc.Movies)
            .WithOne(m => m.ProductionCompany);

        builder.ToTable("ProductionCompanies");
    }
}