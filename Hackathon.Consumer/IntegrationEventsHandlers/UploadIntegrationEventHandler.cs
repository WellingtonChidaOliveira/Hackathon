using Hackathon.IntegrationEvents;
using MassTransit;

namespace Hackathon.Consumer.IntegrationEventsHandlers;

public class UploadIntegrationEventHandler : IConsumer<UploadIntegrationEvent>
{
    public Task Consume(ConsumeContext<UploadIntegrationEvent> context)
    {
        Console.WriteLine($"Received: {context.Message.InputFileName}");
        return Task.CompletedTask;
    }
}