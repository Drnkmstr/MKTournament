using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MKTournament.Application.Abstractions.Email;
using MKTournament.Domain.Abstractions;
using MKTournament.Domain.Players;
using MKTournament.Infrastructure.Persistence;
using MKTournament.Infrastructure.Repositories;
using MKTournament.Infrastructure.Services.Email;

namespace MKTournament.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        AddPersistence(serviceCollection, configuration);
        AddEmail(serviceCollection);
    }

    #region Methods

    private static void AddPersistence(
        IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database") ??
                               throw new ArgumentException(null, nameof(configuration));

        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        
        // Repositories go there
        serviceCollection.AddScoped<IPlayerRepository, PlayerRepository>();

        serviceCollection.AddScoped<IUnitOfWork>(sp => 
            sp.GetRequiredService<ApplicationDbContext>());
    }

    private static void AddEmail(
        IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IEmailService, EmailService>();
    }

    #endregion
}