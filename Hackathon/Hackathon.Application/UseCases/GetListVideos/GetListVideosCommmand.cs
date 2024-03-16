using Hackathon.Domain.Util;
using MediatR;

namespace Hackathon.Application.UseCases.GetListVideos
{
    public record GetListVideosCommmand : IRequest<Result>
    {
    }
}
