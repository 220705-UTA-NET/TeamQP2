using GameReviewAPI.Model;

namespace GameReviewAPI.Data
{
    public interface PlatformsIRepository
    {
        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
    }
}
