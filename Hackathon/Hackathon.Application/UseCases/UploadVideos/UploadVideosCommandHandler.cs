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

                foreach (var file in request.files)
                {
                    var notification = new UploadIntegrationEvent
                    {
                        InputFileName = file.FileName,
                    };

                    var massTransitSettings = _configuration.GetSection("MassTransitSettings").Get<MassTransitSettings>();

                    var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{massTransitSettings?.EndpointName}"));
                    await endpoint.Send(notification);


                    await using FileStream fs = new FileStream($"/upload/{file.FileName}", FileMode.Create);
                    await file.CopyToAsync(fs);
                    
                }
;

                return ReturnResult.Ok("Videos uploaded successfully. Please wait a few minutes and verify in the list.");
            }
            catch (Exception ex)
            {
                return ReturnResult.Fail($"Failed to upload videos: {ex.Message}");
            }
        }
    }
}
