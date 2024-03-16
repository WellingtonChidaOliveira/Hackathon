using Hackathon.Domain.Abstractions;
using Hackathon.Domain.Util;
using Hackathon.Domain.Videos;
using MediatR;

namespace Hackathon.Application.UseCases.GetListVideos
{
    internal sealed class GetListVideosCommmandHandler : IRequestHandler<GetListVideosCommmand, Result>
    {
        private readonly IRepository _repository;

        public GetListVideosCommmandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(GetListVideosCommmand request, CancellationToken cancellationToken)
        {
            List<Video> videos = await _repository.GetListVideos();

            return ReturnResult.Ok("Videos retrieved successfully", videos);
        }
    }
}
