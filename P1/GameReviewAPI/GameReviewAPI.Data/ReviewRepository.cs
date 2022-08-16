using Microsoft.Extensions.Logging;
using GameReviewAPI.Model;
using System.Data.SqlClient;

namespace GameReviewAPI.Data
{
    public class ReviewRepository : ReviewIRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<ReviewRepository> _logger;

        public ReviewRepository(string connectionString, ILogger<ReviewRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }
        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            List<Review> reviews = new List<Review>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "SELECT ID, Review, StarRating, UserName, GameTitle, ReviewDate FROM Review.GameReview";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string review = reader.GetString(1);
                int rating = reader.GetInt32(2);
                string reviewerID = reader.GetString(3);
                string gameID = reader.GetString(4);
                DateTime reviewDate = reader.GetDateTime(5);

                Review tmpReview = new Review(id, review, rating, reviewerID, gameID, reviewDate);
                // add a constructor for GameReview
                reviews.Add(tmpReview);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetAllReviewsAsync, returned {0} results", reviews.Count);
            return reviews;
        }
        public async Task<IEnumerable<AverageReview>> GetAverageReviewsDescendingAsync()
        {
            List<AverageReview> reviews = new List<AverageReview>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "SELECT ROUND(AVG(Cast(StarRating as Float)),2) AS Rating, GameTitle FROM Review.GameReview GROUP BY GameTitle ORDER BY Rating DESC";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                double rating = reader.GetDouble(0);
                string gameTitle = reader.GetString(1);

                AverageReview tmpReview = new AverageReview(rating, gameTitle);
                // add a constructor for GameReview
                reviews.Add(tmpReview);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetAverageReviewsDescendingAsync, returned {0} results", reviews.Count);
            return reviews;
        }
        public async Task<IEnumerable<AverageReview>> GetAverageReviewsAscendingAsync()
        {
            List<AverageReview> reviews = new List<AverageReview>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "SELECT ROUND(AVG(Cast(StarRating as Float)),2) AS Rating, GameTitle FROM Review.GameReview GROUP BY GameTitle ORDER BY Rating ASC";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                double rating = reader.GetDouble(0);
                string gameTitle = reader.GetString(1);

                AverageReview tmpReview = new AverageReview(rating, gameTitle);
                // add a constructor for GameReview
                reviews.Add(tmpReview);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetAverageReviewsDescendingAsync, returned {0} results", reviews.Count);
            return reviews;
        }
        public async Task<IEnumerable<Review>> GetReviewsByIDAsync(string id)
        {
            List<Review> reviews = new List<Review>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = $"SELECT ID, Review, StarRating, UserName, GameTitle, ReviewDate FROM Review.GameReview WHERE UserName like '%{id}%'";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int userID = reader.GetInt32(0);
                string review = reader.GetString(1);
                int rating = reader.GetInt32(2);
                string reviewerID = reader.GetString(3);
                string gameID = reader.GetString(4);
                DateTime reviewDate = reader.GetDateTime(5);

                Review tmpReview = new Review(userID, review, rating, reviewerID, gameID, reviewDate);
                // add a constructor for GameReview
                reviews.Add(tmpReview);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetReviewsByIDAsync, returned {0} results", reviews.Count);
            return reviews;
        }
        public async Task PostInsertReviewAsync(string review, int starRating, string userName, string gameTitle)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            DateTime reviewTime = DateTime.Now;

            string cmdText = "INSERT INTO Review.GameReview (Review, StarRating, UserName, GameTitle, ReviewDate) VALUES (@review,@starRating,@userName,@gameTitle,@reviewTime)";

            using SqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@review", review);
            cmd.Parameters.AddWithValue("@starRating", starRating);
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@gameTitle", gameTitle);
            cmd.Parameters.AddWithValue("@reviewTime", reviewTime);
            await cmd.ExecuteReaderAsync();

            await connection.CloseAsync();
            _logger.LogInformation("Executed PostInsertReviewAsync");
            return;
        }
        public async Task DeleteReviewAsync(string UserName, string GameTitle)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = $"DELETE FROM Review.GameReview WHERE UserName LIKE '%{UserName}%' AND GameTitle LIKE '%{GameTitle}%'";

            using SqlCommand cmd = new(cmdText, connection);

            await cmd.ExecuteReaderAsync();

            await connection.CloseAsync();
            _logger.LogInformation("Executed PostInsertReviewAsync");
            return;
        }
        public async Task<IEnumerable<GameReview>> GetAllReviewsForGameAsync(string game)
        {
            List<GameReview> gameReviews = new List<GameReview>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = $"SELECT UserName, GameTitle, Review, StarRating, ReviewDate FROM Review.GameReview WHERE GameTitle LIKE '%{game}%'";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                string userID = reader.GetString(0);
                string title = reader.GetString(1);
                string review = reader.GetString(2);
                int starRating = reader.GetInt32(3);
                DateTime reviewDate = reader.GetDateTime(4);

                GameReview tmpGameReview = new GameReview(userID, title, review, starRating, reviewDate);
                // add a constructor for GameReview
                gameReviews.Add(tmpGameReview);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetAllReviewsForGameAsync, returned {0} results", gameReviews.Count);
            return gameReviews;
        }
    }
}
