using Hackathon.Domain.Message;
using Hackathon.Domain.Util;
using Hackathon.IntegrationEvents;
using Hackathon.Persistence.Settings;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Hackathon.Application.UseCases.UploadVideos
{
    internal sealed class UploadVideosCommandHandler : IRequestHandler<UploadVideosCommand, Result>
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;
        public UploadVideosCommandHandler(IConfiguration congifuration, IBus bus)
        {
            _configuration = congifuration;
            _bus = bus;
        }

        public async Task<Result> Handle(UploadVideosCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var notification = new UploadIntegrationEvent
                {
                    //NotificationDate = DateTime.Now,
                    InputFileName = request.InputFileName,
                };

                var massTransitSettings = _configuration.GetSection("MassTransitSettings").Get<MassTransitSettings>();


                var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{massTransitSettings?.EndpointName}"));
                await endpoint.Send(notification);

                return ReturnResult.Ok("Videos uploaded successfully. Please wait a few minutes and verify in the list.");
            }
            catch (Exception ex)
            {
                return ReturnResult.Fail($"Failed to upload videos: {ex.Message}");
            }
        }
    }
}
