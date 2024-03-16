namespace Hackathon.Domain.Util
{
    public class ClassBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CratedAt { get; set; } = DateTime.UtcNow;
    }
}
