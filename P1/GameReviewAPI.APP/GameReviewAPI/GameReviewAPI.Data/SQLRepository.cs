using Microsoft.Extensions.Logging;
using GameReviewAPI.Model;
using System.Data.SqlClient;

namespace GameReviewAPI.Data
{
    public class SQLRepository : IRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<SQLRepository> _logger;

        public SQLRepository(string connectionString, ILogger<SQLRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }
        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            List<Review> reviews = new List<Review>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "SELECT ID, Review, StarRating, ReviewerID, GameID, ReviewDate FROM Review.GameReview";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string review = reader.GetString(1);
                int rating = reader.GetInt32(2);
                int reviewerID = reader.GetInt32(3);
                int gameID = reader.GetInt32(4);
                DateTime reviewDate = reader.GetDateTime(5);

                Review tmpReview = new Review(id,review,rating,reviewerID,gameID,reviewDate);
                // add a constructor for GameReview
                reviews.Add(tmpReview);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetAllReviewsAsync, returned {0} results",reviews.Count);
            return reviews;
        }
        public async Task<IEnumerable<AverageReview>> GetAverageReviewsDescendingAsync()
        {
            List<AverageReview> reviews = new List<AverageReview>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "SELECT ROUND(AVG(Cast(StarRating as Float)),2) AS Rating, GameTitle FROM Review.GameReview JOIN Review.Game AS g ON GameID = g.ID GROUP BY GameTitle ORDER BY Rating DESC";

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

            string cmdText = "SELECT ROUND(AVG(Cast(StarRating as Float)),2) AS Rating, GameTitle FROM Review.GameReview JOIN Review.Game AS g ON GameID = g.ID GROUP BY GameTitle ORDER BY Rating ASC"; 

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
        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            List<Game> games = new List<Game>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "SELECT ID, GameTitle, GameDeveloper, GameGenre, YearPublished FROM Review.Game";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string title = reader.GetString(1);
                string developer = reader.GetString(2);
                string genre = reader.GetString(3);
                int yearPublished = reader.GetInt32(4);

                Game tmpGame = new Game(id, title, developer, genre, yearPublished);
                // add a constructor for GameReview
                games.Add(tmpGame);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetAllGamesAsync, returned {0} results", games.Count);
            return games;
        }
        public async Task<IEnumerable<Reviewer>> GetAllReviewersAsync()
        {
            List<Reviewer> reviewers = new List<Reviewer>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "SELECT ID, UserID, Password FROM Review.Reviewer";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string user = reader.GetString(1);
                string password = reader.GetString(2);

                Reviewer tmpReviewer = new Reviewer(id, user, password);
                // add a constructor for GameReview
                reviewers.Add(tmpReviewer);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetAllReviewersAsync, returned {0} results", reviewers.Count);
            return reviewers;
        }
        public async Task<string> GetReviewerAsync(int id)
        {
            string reviewer = "";
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = $"SELECT UserID FROM Review.Reviewer WHERE ID = {id}";
            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            while (reader.Read())
            {
                reviewer = reader.GetString(0);
            }
            return reviewer;
        }
        public async Task<IEnumerable<Game>> GetGamesByDeveloperAsync(string developer)
        {
            List<Game> games = new List<Game>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = $"SELECT ID, GameTitle, GameDeveloper, GameGenre, YearPublished FROM Review.Game WHERE GameDeveloper like '%{developer}%'";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string title = reader.GetString(1);
                string developerName = reader.GetString(2);
                string genre = reader.GetString(3);
                int yearPublished = reader.GetInt32(4);

                Game tmpGame = new Game(id, title, developer, genre, yearPublished);
                
                games.Add(tmpGame);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetGamesByDeveloperAsync, returned {0} results", games.Count);
            return games;
        }
        public async Task<IEnumerable<Review>> GetReviewsByIDAsync(int id)
        {
            List<Review> reviews = new List<Review>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = $"SELECT ID, Review, StarRating, ReviewerID, GameID, ReviewDate FROM Review.GameReview WHERE ReviewerID = {id}";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int userID = reader.GetInt32(0);
                string review = reader.GetString(1);
                int rating = reader.GetInt32(2);
                int reviewerID = reader.GetInt32(3);
                int gameID = reader.GetInt32(4);
                DateTime reviewDate = reader.GetDateTime(5);

                Review tmpReview = new Review(id, review, rating, reviewerID, gameID, reviewDate);
                // add a constructor for GameReview
                reviews.Add(tmpReview);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetReviewsByIDAsync, returned {0} results", reviews.Count);
            return reviews;
        }
        public async Task<IEnumerable<Game>> GetGamesByGenreAsync(string genre)
        {
            List<Game> games = new List<Game>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = $"SELECT ID, GameTitle, GameDeveloper, GameGenre, YearPublished FROM Review.Game WHERE GameGenre like '%{genre}%'";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string title = reader.GetString(1);
                string developerName = reader.GetString(2);
                string gameGenre = reader.GetString(3);
                int yearPublished = reader.GetInt32(4);

                Game tmpGame = new Game(id, title,developerName,gameGenre,yearPublished);
                // add a constructor for GameReview
                games.Add(tmpGame);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetReviewsByIDAsync, returned {0} results", games.Count);
            return games;
        }
        public async Task PostInsertReviewerAsync(string userId,string password)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "INSERT INTO Review.Reviewer (UserID, Password) VALUES (@userId,@password)";

            using SqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@userID",userId);
            cmd.Parameters.AddWithValue("@password", password);
            await cmd.ExecuteReaderAsync();

            await connection.CloseAsync();
            _logger.LogInformation("Executed PostInsertReviewerAsync");
            return;
        }

        public async Task PostInsertGameAsync(string gameTitle, string gameDeveloper, string gameGenre, int yearPublished)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "INSERT INTO Review.Game (GameTitle, GameDeveloper, GameGenre, YearPublished) VALUES (@gameTitle,@gameDeveloper,@gameGenre,@yearPublished)";

            using SqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@gameTitle", gameTitle);
            cmd.Parameters.AddWithValue("@gameDeveloper", gameDeveloper);
            cmd.Parameters.AddWithValue("@gameGenre", gameGenre);
            cmd.Parameters.AddWithValue("@yearPublished", yearPublished);
            await cmd.ExecuteReaderAsync();

            await connection.CloseAsync();
            _logger.LogInformation("Executed PostInsertGameAsync");
            return;
        }

        public async Task PostInsertReviewAsync(string review, int starRating, int reviewerID, int gameID)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            DateTime reviewTime = DateTime.Now;

            string cmdText = "INSERT INTO Review.GameReview (Review, StarRating, ReviewerID,GameID, ReviewDate) VALUES (@review,@starRating,@reviewerID,@gameID,@reviewTime)";

            using SqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@review", review);
            cmd.Parameters.AddWithValue("@starRating", starRating);
            cmd.Parameters.AddWithValue("@reviewerID", reviewerID);
            cmd.Parameters.AddWithValue("@gameID", gameID);
            cmd.Parameters.AddWithValue("@reviewTime", reviewTime);
            await cmd.ExecuteReaderAsync();

            await connection.CloseAsync();
            _logger.LogInformation("Executed PostInsertReviewAsync");
            return;
        }
        public async Task PostDeleteReviewAsync(int reviewerID, int gameID)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "DELETE FROM Review.GameReview WHERE ReviewerID = @reviewerID AND GameID = @gameID";

            using SqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@reviewerID", reviewerID);
            cmd.Parameters.AddWithValue("@gameID", gameID);

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

            string cmdText = "SELECT r.UserID, g.GameTitle, Review, StarRating, ReviewDate FROM Review.GameReview JOIN Review.Reviewer AS r ON r.ID = ReviewerID JOIN Review.Game AS g ON g.ID = GameID WHERE g.GameTitle = @game";

            using SqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@game", game);
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