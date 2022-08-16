using GameReviewAPI.Model;

namespace GameReviewAPI.Data
{
    public interface UserIRepository
    {
        Task<string> GetUserAsync(int id);
        Task PostInsertUserAsync(string userID, string password);
    }
}
