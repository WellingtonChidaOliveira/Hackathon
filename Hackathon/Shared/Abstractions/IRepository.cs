using Hackathon.Domain.Videos;

namespace Hackathon.Domain.Abstractions
{
    public interface IRepository
    {
        Task<List<Video>> GetListVideos();
    }
}
