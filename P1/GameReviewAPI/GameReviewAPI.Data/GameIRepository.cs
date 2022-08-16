
using GameReviewAPI.Model;

namespace GameReviewAPI.Data
{
    public interface GameIRepository
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<IEnumerable<Game>> GetGamesByDeveloperAsync(string developer);
        Task<IEnumerable<Game>> GetGamesByTagsAsync(string genre);
        Task PostInsertGameAsync(string gameTitle, string gameDeveloper, string gamePublisher, int yearPublished);
    }
}
