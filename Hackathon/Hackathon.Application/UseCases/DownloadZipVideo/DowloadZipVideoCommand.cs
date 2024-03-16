using Hackathon.Domain.Util;
using MediatR;

namespace Hackathon.Application.UseCases.DownloadZipVideo
{
    public record DowloadZipVideoCommand(string pathZip) : IRequest<Result>
    {
    }
}
