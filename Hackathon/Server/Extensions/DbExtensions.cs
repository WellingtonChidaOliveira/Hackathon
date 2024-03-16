using Hackathon.Domain.Videos;
using Hackathon.Persistence.Data.Contexts;
using Hackathon.Persistence.Data.Features.Videos;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Server.Extensions;

public static class DbExtensions
{
    public static void AddDbServices(this IServiceCollection services, IConfiguration configuration)
    {
        var sectionName = "HackhathonDBConnection";
        var connectionStringDb = configuration.GetConnectionString(sectionName);

        services.AddDbContext<HackathonDBContext>(options => {
            options.UseNpgsql(connectionStringDb);
        });

        AddRepositories(services);
    }

    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            using (var dbContext = scope.ServiceProvider.GetRequiredService<HackathonDBContext>())
            {
                dbContext.Database.Migrate();
            }
        }

        return app;
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IVideoRepository, VideoRepository>();
    }
}
