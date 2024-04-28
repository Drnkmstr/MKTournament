using Microsoft.Extensions.DependencyInjection;
using MKTournament.Application.Abstractions.Behaviors;

namespace MKTournament.Application;

public static class DependencyInjection
{
    public static void AddApplicationLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
    }
}