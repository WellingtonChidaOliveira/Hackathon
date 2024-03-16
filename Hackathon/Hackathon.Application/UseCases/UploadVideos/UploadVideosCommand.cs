using Hackathon.Domain.Util;
using Hackathon.Domain.Videos;
using MediatR;

namespace Hackathon.Application.UseCases.UploadVideos
{
    public record UploadVideosCommand(string InputFileName) : IRequest<Result>;
    
}
