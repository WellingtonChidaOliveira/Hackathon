using Hackathon.Domain.Message;
using Hackathon.Domain.Util;
using MediatR;

namespace Hackathon.Application.UseCases.UploadVideos
{
    internal sealed class UploadVideosCommandHandler : IRequestHandler<UploadVideosCommand, Result>
    {
        private readonly IPublisher _publisher;

        public UploadVideosCommandHandler(IPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task<Result> Handle(UploadVideosCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var notification = new NotificationCreated
                {
                    NotificationDate = DateTime.Now,
                    NotificationMessage = request.video.InputFileName,
                };

                await _publisher.Publish(notification, cancellationToken);
                return ReturnResult.Ok("Videos uploaded successfully. Please wait a few minutes and verify in the list.");
            }
            catch (Exception ex)
            {
                return ReturnResult.Fail($"Failed to upload videos: {ex.Message}");
            }
        }
    }
}
