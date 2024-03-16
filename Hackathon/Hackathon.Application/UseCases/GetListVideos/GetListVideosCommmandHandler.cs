using Hackathon.Domain.Util;
using Hackathon.Domain.Videos;
using MediatR;

namespace Hackathon.Application.UseCases.GetListVideos
{
    internal sealed class GetListVideosCommmandHandler : IRequestHandler<GetListVideosCommmand, Result>
    {
        private readonly IVideoRepository _repository;

        public GetListVideosCommmandHandler(IVideoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(GetListVideosCommmand request, CancellationToken cancellationToken)
        {
            List<Video> videos = await _repository.GetAll();

            return ReturnResult.Ok("Videos retrieved successfully", videos);
        }
    }
}
