using Hackathon.Domain.Abstractions;
using Hackathon.Domain.Util;
using MediatR;

namespace Hackathon.Application.UseCases.UploadVideos
{
    internal sealed class UploadVideosCommandHandler : IRequestHandler<UploadVideosCommand, Result>
    {
        private readonly IMassTransit _queue;

        public UploadVideosCommandHandler(IMassTransit queue)
        {
            _queue = queue;
        }

        public async Task<Result> Handle(UploadVideosCommand request, CancellationToken cancellationToken)
        {
           await _queue.Publish(request.video.InputFileName);

            return new Result
            {
                Message = "Videos uploaded successfully, await some minutes and verify in list",
                Success = true,
                Data = null
            };
        }
    }   
    
}
