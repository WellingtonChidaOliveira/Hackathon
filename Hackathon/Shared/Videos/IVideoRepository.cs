namespace Hackathon.Domain.Videos;

public interface IVideoRepository
{
    Task<List<Video>> GetAll();
}
