namespace GameReviewAPI.APP
{
    public class Review
    {
        public int id { get; set; }
        public string review { get; set; }
        public int starRating { get; set; }
        public int reviewerID { get; set; }
        public int gameID { get; set; }
        public DateTime reviewDate { get; set; }
        public Review(string review, int StarRating, int ReviewerID, int GameID, DateTime ReviewDate)
        {
            this.review = review;
            this.starRating = StarRating;
            this.reviewerID = ReviewerID;
            this.gameID = GameID;
            this.reviewDate = ReviewDate;
        }
        public override string ToString()
        {
            return $"ID: {id} Review: {review} Rating: {starRating} ReviewerID: {reviewerID} GameID: {gameID} ReviewDate: {reviewDate}";
        }
    }
}
