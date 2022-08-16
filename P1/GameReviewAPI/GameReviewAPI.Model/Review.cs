namespace GameReviewAPI.Model
{
    public class Review
    {
        public int ID { get; }
        public string review { get; set; }
        public int starRating { get; set; }
        public string userName { get; set; }
        public string gameTitle { get; set; }
        public DateTime reviewDate { get; set; }

        public Review() { }
        public Review(int ID, string review, int StarRating, string userName, string gameTitle, DateTime ReviewDate)
        {
            this.ID = ID;
            this.review = review;
            this.starRating = StarRating;
            this.userName = userName;
            this.gameTitle = gameTitle;
            this.reviewDate = ReviewDate;
        }
    }
}