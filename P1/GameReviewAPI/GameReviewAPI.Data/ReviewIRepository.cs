using GameReviewAPI.Model;

namespace GameReviewAPI.Data
{
    public interface ReviewIRepository
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<IEnumerable<AverageReview>> GetAverageReviewsDescendingAsync();
        Task<IEnumerable<AverageReview>> GetAverageReviewsAscendingAsync();

        //this one is probebaly going to be changed/removed
        Task<IEnumerable<Review>> GetReviewsByIDAsync(int id);
        Task PostInsertReviewAsync(string review, int starRating, int reviewerID, int gameID);
        Task DeleteReviewAsync(int reviewerID, int gameID);
        Task<IEnumerable<GameReview>> GetAllReviewsForGameAsync(string game);
    }
}
