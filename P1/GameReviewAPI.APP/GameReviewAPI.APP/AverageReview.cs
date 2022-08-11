using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReviewAPI.APP
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
        public override string ToString()
        {
            return $"AverageRating: {averageRating} GameTitle: {gameTitle}";
        }
    }
}
