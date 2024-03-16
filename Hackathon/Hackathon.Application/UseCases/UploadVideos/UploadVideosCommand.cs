using Hackathon.Domain.Util;
using Hackathon.Domain.Videos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Hackathon.Application.UseCases.UploadVideos
{
    public record UploadVideosCommand(List<IFormFile> files) : IRequest<Result>;
    
}
