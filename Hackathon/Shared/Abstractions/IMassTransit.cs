namespace Hackathon.Domain.Abstractions
{
    public interface IMassTransit
    {
        Task Publish<T>(T message) where T : class;
    }
}
