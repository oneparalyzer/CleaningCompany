using CleaningCompany.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleaningCompany.MVC.Extentions;

public static class ApplicationBuilderExtension
{
    public static void UseDatabaseMigrations(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}
