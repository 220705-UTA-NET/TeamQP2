using Microsoft.Extensions.Logging;
using GameReviewAPI.Model;
using System.Data.SqlClient;

namespace GameReviewAPI.Data
{
    public class UserRepository : UserIRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(string connectionString, ILogger<UserRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }
        public async Task<string> GetUserAsync(int id)
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

        public async Task PostInsertUserAsync(string userId, string password)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "INSERT INTO Review.Reviewer (UserID, Password) VALUES (@userId,@password)";

            using SqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@userID", userId);
            cmd.Parameters.AddWithValue("@password", password);
            await cmd.ExecuteReaderAsync();

            await connection.CloseAsync();
            _logger.LogInformation("Executed PostInsertReviewerAsync");
            return;
        }
    }
}
