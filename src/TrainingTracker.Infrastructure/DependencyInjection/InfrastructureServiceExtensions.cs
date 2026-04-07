using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainingTracker.Application.Interfaces;
using TrainingTracker.Infrastructure.Data;
using TrainingTracker.Infrastructure.Services;

namespace TrainingTracker.Infrastructure.DependencyInjection;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var useInMemory = configuration.GetValue<bool>("UseInMemoryDatabase");
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(opt =>
        {
            if (useInMemory)
            {
                opt.UseInMemoryDatabase("TrainingTracker");
                return;
            }

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException(
                    "DefaultConnection is missing. Set it in appsettings.json or enable UseInMemoryDatabase.");

            opt.UseSqlServer(connectionString);
        });

        services.AddScoped<ITrainingWeekService, TrainingWeekService>();

        return services;
    }
}
