using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReviewAPI.Model
{
    public class GameReview
    {
        public string UserID { get; set; }
        public string GameTitle { get; set; }
        public string Review { get; set; }
        public int StarRating { get; set; }
        public DateTime ReviewDate { get; set; }

        public GameReview(string UserID, string GameTitle, string Review, int StarRating, DateTime ReviewDate)
        {
            this.UserID = UserID;
            this.GameTitle = GameTitle;
            this.Review = Review;
            this.StarRating = StarRating;
            this.ReviewDate = ReviewDate;
        }
    }
}
