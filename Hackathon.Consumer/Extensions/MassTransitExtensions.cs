using Hackathon.Consumer.IntegrationEventsHandlers;
using Hackathon.Persistence.Settings;
using MassTransit;

namespace Hackathon.Consumer.Extensions;

public static class MassTransitExtensions
{
    public static void AddMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection("MassTransitSettings").Get<MassTransitSettings>();

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri(settings?.Host), host =>
                {
                    host.Username(settings?.Username);
                    host.Password(settings?.Password);
                });
                cfg.ReceiveEndpoint(settings?.EndpointName, e =>
                {
                    e.Consumer<VideoIntegrationEventHandler>();
                });
                cfg.ConfigureEndpoints(context);
            });

            x.AddConsumer<VideoIntegrationEventHandler>();
        });
    }
}
