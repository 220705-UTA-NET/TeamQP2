namespace GameReviewAPI.Model
{
    public class Review
    {
        public int ID { get; }
        public string review { get; set; }
        public int StarRating { get; set; }
        public int ReviewerID { get; set; }
        public int GameID { get; set; }
        public DateTime ReviewDate { get; set; }

        public Review() { }
        public Review(int ID, string review, int StarRating, int ReviewerID, int GameID, DateTime ReviewDate)
        {
            this.ID = ID;
            this.review = review;
            this.StarRating = StarRating;
            this.ReviewerID = ReviewerID;
            this.GameID = GameID;
            this.ReviewDate = ReviewDate;
        }
    }
}