using Hackathon.Domain.Videos;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Persistence.Data.Contexts;

public class HackathonDBContext : DbContext
{
    public HackathonDBContext(DbContextOptions<HackathonDBContext> options) : base(options)
    {
    }

    public DbSet<Video> Videos { get; set; }
}
