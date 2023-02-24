using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Data;

public static class IdentityDataInitializer
{
    public static void SeedData(ModelBuilder builder)
        {
            SeedRoles(builder);
            SeedUsers(builder);
            SeedUserRoles(builder);
        }

        private static void SeedUsers(ModelBuilder builder)
        {
            builder.Entity<User>().HasData
            (
                new User
                {
                    Id = "3470262F-7571-ED11-B214-D41B81B14CB3",
                    UserName = "Admin", 
                    NormalizedUserName = "Admin",
                    Email = "smith@gmail.com",
                    NormalizedEmail = "SMITH@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEDkYL3RUU/7ScDdxXvD9hB8eYViSrUANyvEFA9M3SPX4HVqrKWaSf8GpATYde6Wibw==",
                    SecurityStamp = "7JBROKPX4RLYJCPXDGP2COQ25X2DFUN5",
                    ConcurrencyStamp = "8288ed6b-3972-47c1-a4bc-fa4fa26e02f5",
                    PhoneNumber = "+38012345678",
                    EmailConfirmed = true
                }
            );
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
            (
                new IdentityRole
                {
                    Id = "4096c786-5577-4bb2-80c9-9c105b90e16f",
                    Name = "Visitor",
                    NormalizedName = "VISITOR",
                    ConcurrencyStamp = "d9f4bb7d-7411-4706-995f-560c7e5b1972"
                },
                new IdentityRole
                {
                    Id = "71be2e68-fa38-4de3-b253-d34f1c16cc9a",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "baf17a47-bf30-42e1-a31e-fac07868dc02"
                }
            );
        }

        private static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData
            (
                new IdentityUserRole<string>
                {
                    RoleId = "71be2e68-fa38-4de3-b253-d34f1c16cc9a",
                    UserId = "3470262F-7571-ED11-B214-D41B81B14CB3"
                }
            );
        }
}