using Microsoft.Extensions.Logging;
using GameReviewAPI.Model;
using System.Data.SqlClient;


namespace GameReviewAPI.Data
{
    public class TagsRepository : TagsIRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<TagsRepository> _logger;

        public TagsRepository(string connectionString, ILogger<TagsRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }
        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            List<Tag> tags = new List<Tag>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "SELECT ID, Genre FROM Review.Tags";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string genre = reader.GetString(1);

                Tag tmpTag = new Tag(id, genre);
                // add a constructor for GameReview
                tags.Add(tmpTag);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetAllTagsAsync, returned {0} results", tags.Count);
            return tags;
        }
    }
}
