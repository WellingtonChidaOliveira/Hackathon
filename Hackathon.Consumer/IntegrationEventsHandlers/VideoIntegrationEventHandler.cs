using Hackathon.IntegrationEvents;
using MassTransit;

namespace Hackathon.Consumer.IntegrationEventsHandlers;

public class VideoIntegrationEventHandler : IConsumer<VideoIntegrationEvent>
{
    public Task Consume(ConsumeContext<VideoIntegrationEvent> context)
    {
        return Task.CompletedTask;
    }
}