using Hackathon.Domain.Videos;

namespace Hackathon.Persistence.Data.Features.Videos;

public class VideoRepository : IVideoRepository
{
    public Task<List<Video>> GetAll()
    {
        throw new NotImplementedException();
    }
}
