using Hackathon.Domain.Util;
using Hackathon.Domain.Videos;
using MediatR;

namespace Hackathon.Application.UseCases.UploadVideos
{
    public record UploadVideosCommand(Video video) : IRequest<Result>;
    
}
