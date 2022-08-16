namespace GameReviewAPI.APP
{
    public class GameReview
    {
        public string userID { get; set; }
        public string gameTitle { get; set; }
        public string review { get; set; }
        public int starRating { get; set; }
        public DateTime reviewDate { get; set; }

        public GameReview(string UserID, string GameTitle, string Review, int StarRating, DateTime ReviewDate)
        {
            this.userID = UserID;
            this.gameTitle = GameTitle;
            this.review = Review;
            this.starRating = StarRating;
            this.reviewDate = ReviewDate;
        }
        public override string ToString()
        {
            return $"ID: {userID} GameTitle: {gameTitle} Review: {review} Rating: {starRating} ReviewDate: {reviewDate}";
        }
    }
}
