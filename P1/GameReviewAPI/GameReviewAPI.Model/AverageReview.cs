

namespace GameReviewAPI.Model
{
    public class AverageReview
    {
        public double averageRating { get; set; }
        public string gameTitle { get; set; }
        public AverageReview(double averageRating, string gameTitle)
        {
            this.averageRating = averageRating;
            this.gameTitle = gameTitle;
        }
    }
}
