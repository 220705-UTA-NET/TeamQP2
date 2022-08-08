namespace GameReviewAPI.Model
{
    public class Entry
    {
        public int ReviewID { get; }
        public int UserID { get; }
        public int GameID { get; set; }
        public string Username { get; set; }
        public string Game { get; set; }
        public string? Review { get; set; }
        public double Rating { get; set; }
        public DateTime ReviewDate { get; set; }

        public Entry() { }
        public Entry(int UserID, int GameID, double Rating, string? Review = null)
        {
            this.UserID = UserID;
            this.Username = $"SELECT Username FROM Reviews WHERE ID = {UserID}";
            this.GameID = GameID;
            this.Game = $"SELECT Name FROM Games WHERE ID = {GameID}";
            this.Rating = Rating;
            this.Review = Review;
        }
    }
}