using GameReviewAPI.Model;

namespace GameReviewAPI.Data
{
    public interface TagsIRepository
    {
        Task<IEnumerable<Tag>> GetAllTagsAsync();
    }
}
