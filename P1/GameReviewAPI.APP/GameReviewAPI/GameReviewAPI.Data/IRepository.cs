
using GameReviewAPI.Model;

namespace GameReviewAPI.Data
{
    public interface IRepository
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<IEnumerable<Reviewer>> GetAllReviewersAsync();
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<IEnumerable<AverageReview>> GetAverageReviewsDescendingAsync();
        Task<IEnumerable<AverageReview>> GetAverageReviewsAscendingAsync();
        Task<string> GetReviewerAsync(int id);
        Task<IEnumerable<Game>> GetGamesByDeveloperAsync(string developer);
        Task<IEnumerable<Review>> GetReviewsByIDAsync(int id);
        Task<IEnumerable<Game>> GetGamesByGenreAsync(string genre);
        Task PostInsertReviewerAsync(string userID, string password);
        Task PostInsertGameAsync(string gameTitle, string gameDeveloper, string gameGenre, int yearPublished);
        Task PostInsertReviewAsync(string review, int starRating, int reviewerID, int gameID);
        Task PostDeleteReviewAsync(int reviewerID, int gameID);
        Task<IEnumerable<GameReview>> GetAllReviewsForGameAsync(string game);
    }
}
