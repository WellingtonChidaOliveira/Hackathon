using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Persistence
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();
                busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
                {
                    busFactoryConfigurator.Host("rabbitmq", hostConfigurator => { });
                });
            });
            return services;
        }
    }
}
