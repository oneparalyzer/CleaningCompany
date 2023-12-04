using CleaningCompany.Domain.AggregateModels.UserAggregate.Enums;
using CleaningCompany.Infrastructure.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleaningCompany.Infrastructure.Persistence;

public static class DataSeeder
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<CustomIdentityRole>().HasData(new List<CustomIdentityRole>()
        {
            new CustomIdentityRole() 
            { 
                Id = Guid.NewGuid(),
                Name = Role.Client.Name,
                NormalizedName = Role.Client.Name.ToUpper(),
            },
            new CustomIdentityRole()
            {
                Id = Guid.NewGuid(),
                Name = Role.Admin.Name,
                NormalizedName = Role.Admin.Name.ToUpper(),
            },
            new CustomIdentityRole()
            {
                Id = Guid.NewGuid(),
                Name = Role.Worker.Name,
                NormalizedName = Role.Worker.Name.ToUpper(),
            }
        });
    }
}
