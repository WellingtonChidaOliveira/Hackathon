using Hackathon.IntegrationEvents;
using MassTransit;

namespace Hackathon.Consumer.IntegrationEventsHandlers;

public class UploadIntegrationEventHandler : IConsumer<UploadIntegrationEvent>
{
    public Task Consume(ConsumeContext<UploadIntegrationEvent> context)
    {
        return Task.CompletedTask;
    }
}