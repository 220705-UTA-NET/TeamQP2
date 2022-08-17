using GameReviewAPI.Model;

namespace GameReviewAPI.Data
{
    public interface ReviewIRepository
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<IEnumerable<AverageReview>> GetAverageReviewsDescendingAsync();
        Task<IEnumerable<AverageReview>> GetAverageReviewsAscendingAsync();
        Task<AverageReview> GetGameAverageReviewAsync(string Title);

        //this one is probebaly going to be changed/removed
        Task<IEnumerable<Review>> GetReviewsByIDAsync(string id);
        Task PostInsertReviewAsync(string review, int starRating, string UserName, string GameTitle);
        Task DeleteReviewAsync(string UserName, string GameTitle);
        Task<IEnumerable<GameReview>> GetAllReviewsForGameAsync(string game);
    }
}
