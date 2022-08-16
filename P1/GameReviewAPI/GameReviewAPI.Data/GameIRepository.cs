
using GameReviewAPI.Model;

namespace GameReviewAPI.Data
{
    public interface GameIRepository
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<IEnumerable<Game>> GetGamesByDeveloperAsync(string developer);
        Task<IEnumerable<Game>> GetGamesByTagsAsync(string genre);
        Task<IEnumerable<Game>> GetGamesByPlatformAsync(string platform);
        Task<IEnumerable<Game>> GetGamesByTitleAsync(string title);
        Task PostInsertGameAsync(string gameTitle, string gameDeveloper, string gamePublisher, int yearPublished);
        Task PostInsertGameTagsAsync(string gameTitle,string tag);
        Task PostInsertGamePlatformAsync(string gameTitle,string platform);
    }
}
