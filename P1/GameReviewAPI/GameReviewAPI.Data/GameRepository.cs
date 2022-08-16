using Microsoft.Extensions.Logging;
using GameReviewAPI.Model;
using System.Data.SqlClient;

namespace GameReviewAPI.Data
{
    public class GameRepository : GameIRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<GameRepository> _logger;

        public GameRepository(string connectionString, ILogger<GameRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }
        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            List<Game> games = new List<Game>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string gameCmdText = "SELECT ID, GameTitle, GameDeveloper, GamePublisher, YearPublished FROM Review.Game";

            using SqlCommand cmd = new(gameCmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string title = reader.GetString(1);
                string developer = reader.GetString(2);
                string publisher = reader.GetString(3);
                int yearPublished = reader.GetInt32(4);
                List<Tag> tags = new List<Tag>();
                List<Platform> platforms = new List<Platform>();
                // insert the loops 
                string tagsCmdText = $"SELECT t.ID, t.Genre FROM Review.Game as g JOIN Review.GameTags as gt on g.ID = gt.GameID JOIN Review.Tags as t on t.ID = gt.TagID WHERE g.ID = {id}";
                using SqlCommand tagCmd = new(tagsCmdText, connection);
                using SqlDataReader tagReader = await tagCmd.ExecuteReaderAsync();

                while (tagReader.Read())
                {
                    int tagId = tagReader.GetInt32(0);
                    string tagTitle = tagReader.GetString(1);
                    Tag tmpTag = new Tag(tagId, tagTitle);
                    tags.Add(tmpTag);
                }
                string platformCmdText = $"SELECT p.ID, p.ConsoleName FROM Review.Game as g JOIN Review.GamePlatform as gp on g.ID = gp.GameID JOIN Review.Platform as p on p.ID = gp.PlatformID WHERE g.ID = {id}";

                using SqlCommand platformCmd = new(platformCmdText, connection);
                using SqlDataReader platformReader = await platformCmd.ExecuteReaderAsync();
                while (platformReader.Read())
                {
                    int platformId = platformReader.GetInt32(0);
                    string platformTitle = platformReader.GetString(1);
                    Platform tmpPlatform = new Platform(platformId, platformTitle);
                    platforms.Add(tmpPlatform);
                }
                Game tmpGame = new Game(id, title, developer, publisher, tags, platforms, yearPublished);
                
                games.Add(tmpGame);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetAllGamesAsync, returned {0} results", games.Count);
            return games;
        }
        public async Task<IEnumerable<Game>> GetGamesByDeveloperAsync(string developer)
        {
            List<Game> games = new List<Game>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = $"SELECT ID, GameTitle, GameDeveloper, GamePublisher, YearPublished FROM Review.Game WHERE GameDeveloper like '%{developer}%'";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string title = reader.GetString(1);
                string developerName = reader.GetString(2);
                string publisherName = reader.GetString(3);
                int yearPublished = reader.GetInt32(4);

                List<Tag> tags = new List<Tag>();
                List<Platform> platforms = new List<Platform>();

                string tagsCmdText = $"SELECT t.ID, t.Genre FROM Review.Game as g JOIN Review.GameTags as gt on g.ID = gt.GameID JOIN Review.Tags as t on t.ID = gt.TagID WHERE g.ID = {id}";
                using SqlCommand tagCmd = new(tagsCmdText, connection);
                using SqlDataReader tagReader = await tagCmd.ExecuteReaderAsync();
                while (tagReader.Read())
                {
                    int tagId = tagReader.GetInt32(0);
                    string tagTitle = tagReader.GetString(1);
                    Tag tmpTag = new Tag(tagId, tagTitle);
                    tags.Add(tmpTag);
                }

                string platformCmdText = $"SELECT p.ID, p.ConsoleName FROM Review.Game as g JOIN Review.GamePlatform as gp on g.ID = gp.GameID JOIN Review.Platform as p on p.ID = gp.PlatformID WHERE g.ID = {id}";
                using SqlCommand platformCmd = new(platformCmdText, connection);
                using SqlDataReader platformReader = await platformCmd.ExecuteReaderAsync();
                while (platformReader.Read())
                {
                    int platformId = platformReader.GetInt32(0);
                    string platformTitle = platformReader.GetString(1);
                    Platform tmpPlatform = new Platform(platformId, platformTitle);
                    platforms.Add(tmpPlatform);
                }
                Game tmpGame = new Game(id, title, developerName, publisherName, tags, platforms, yearPublished);

                games.Add(tmpGame);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetGamesByDeveloperAsync, returned {0} results", games.Count);
            return games;
        }
        
        //this needs to be able to account for multiple tags
        public async Task<IEnumerable<Game>> GetGamesByTagsAsync(string genre)
        {
            List<Game> games = new List<Game>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = $"SELECT g.ID, g.GameTitle, g.GameDeveloper, g.GamePublisher, g.YearPublished FROM Review.Game as g JOIN Review.GameTags as gt on gt.GameID = g.ID JOIN Review.Tags as t on t.ID = gt.TagID WHERE t.Genre like '%{genre}%'";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string title = reader.GetString(1);
                string developerName = reader.GetString(2);
                string publisherName = reader.GetString(3);
                int yearPublished = reader.GetInt32(4);
                List<Tag> tags = new List<Tag>();
                List<Platform> platforms = new List<Platform>();

                string tagsCmdText = $"SELECT t.ID, t.Genre FROM Review.Game as g JOIN Review.GameTags as gt on g.ID = gt.GameID JOIN Review.Tags as t on t.ID = gt.TagID WHERE g.ID = {id}";
                using SqlCommand tagCmd = new(tagsCmdText, connection);
                using SqlDataReader tagReader = await tagCmd.ExecuteReaderAsync();
                while (tagReader.Read())
                {
                    int tagId = tagReader.GetInt32(0);
                    string tagTitle = tagReader.GetString(1);
                    Tag tmpTag = new Tag(tagId, tagTitle);
                    tags.Add(tmpTag);
                }

                string platformCmdText = $"SELECT p.ID, p.ConsoleName FROM Review.Game as g JOIN Review.GamePlatform as gp on g.ID = gp.GameID JOIN Review.Platform as p on p.ID = gp.PlatformID WHERE g.ID = {id}";
                using SqlCommand platformCmd = new(platformCmdText, connection);
                using SqlDataReader platformReader = await platformCmd.ExecuteReaderAsync();
                while (platformReader.Read())
                {
                    int platformId = platformReader.GetInt32(0);
                    string platformTitle = platformReader.GetString(1);
                    Platform tmpPlatform = new Platform(platformId, platformTitle);
                    platforms.Add(tmpPlatform);
                }
                Game tmpGame = new Game(id, title, developerName, publisherName, tags, platforms, yearPublished);
                games.Add(tmpGame);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetReviewsByIDAsync, returned {0} results", games.Count);
            return games;
        }
        public async Task<IEnumerable<Game>> GetGamesByPlatformAsync(string platform)
        {
            List<Game> games = new List<Game>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = $"SELECT g.ID, g.GameTitle, g.GameDeveloper, g.GamePublisher, g.YearPublished FROM Review.Game as g JOIN Review.GamePlatform as gp on gp.GameID = g.ID JOIN Review.Platform as p on p.ID = gp.PlatformID WHERE p.ConsoleName LIKE '%{platform}%'";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string title = reader.GetString(1);
                string developerName = reader.GetString(2);
                string publisherName = reader.GetString(3);
                int yearPublished = reader.GetInt32(4);
                List<Tag> tags = new List<Tag>();
                List<Platform> platforms = new List<Platform>();

                string tagsCmdText = $"SELECT t.ID, t.Genre FROM Review.Game as g JOIN Review.GameTags as gt on g.ID = gt.GameID JOIN Review.Tags as t on t.ID = gt.TagID WHERE g.ID = {id}";
                using SqlCommand tagCmd = new(tagsCmdText, connection);
                using SqlDataReader tagReader = await tagCmd.ExecuteReaderAsync();
                while (tagReader.Read())
                {
                    int tagId = tagReader.GetInt32(0);
                    string tagTitle = tagReader.GetString(1);
                    Tag tmpTag = new Tag(tagId, tagTitle);
                    tags.Add(tmpTag);
                }

                string platformCmdText = $"SELECT p.ID, p.ConsoleName FROM Review.Game as g JOIN Review.GamePlatform as gp on g.ID = gp.GameID JOIN Review.Platform as p on p.ID = gp.PlatformID WHERE g.ID = {id}";
                using SqlCommand platformCmd = new(platformCmdText, connection);
                using SqlDataReader platformReader = await platformCmd.ExecuteReaderAsync();
                while (platformReader.Read())
                {
                    int platformId = platformReader.GetInt32(0);
                    string platformTitle = platformReader.GetString(1);
                    Platform tmpPlatform = new Platform(platformId, platformTitle);
                    platforms.Add(tmpPlatform);
                }
                Game tmpGame = new Game(id, title, developerName, publisherName, tags, platforms, yearPublished);
                games.Add(tmpGame);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetReviewsByIDAsync, returned {0} results", games.Count);
            return games;
        }
        public async Task PostInsertGameAsync(string gameTitle, string gameDeveloper, string gamePublisher, int yearPublished)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "INSERT INTO Review.Game (GameTitle, GameDeveloper, GamePublisher, YearPublished) VALUES (@gameTitle,@gameDeveloper,@gamePublisher,@yearPublished)";

            using SqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@gameTitle", gameTitle);
            cmd.Parameters.AddWithValue("@gameDeveloper", gameDeveloper);
            cmd.Parameters.AddWithValue("@gamePublisher", gamePublisher);
            cmd.Parameters.AddWithValue("@yearPublished", yearPublished);
            await cmd.ExecuteReaderAsync();

            await connection.CloseAsync();
            _logger.LogInformation("Executed PostInsertGameAsync");
            return;
        }
        public async Task PostInsertGameTagsAsync(string gameTitle, string tag)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            string selectGameCmdText = $"SELECT ID FROM Review.Game WHERE GameTitle LIKE '%{gameTitle}%'";
            using SqlCommand gameCmd = new(selectGameCmdText, connection);
            using SqlDataReader gameIDReader = await gameCmd.ExecuteReaderAsync();
            int gameID = 0;
            int tagID = 0;
            while (gameIDReader.Read())
            { 
                gameID = gameIDReader.GetInt32(0);
            }
            string selectTagCmdText = $"SELECT ID FROM Review.Tags WHERE Genre LIKE '%{tag}%'";
            using SqlCommand tagCmd = new(selectTagCmdText, connection);
            using SqlDataReader tagIDReader = await tagCmd.ExecuteReaderAsync();
            while (tagIDReader.Read())
            {
                tagID = tagIDReader.GetInt32(0);
            }
            string cmdText = "INSERT INTO Review.GameTags (GameID, TagID) VALUES (@gameID,@tagID)";
            using SqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@gameID", gameID);
            cmd.Parameters.AddWithValue("@tagID", tagID);
            await cmd.ExecuteReaderAsync();

            await connection.CloseAsync();
            _logger.LogInformation("Executed PostInsertGameAsync");
            return;
        }
        public async Task PostInsertGamePlatformAsync(string gameTitle, string platform)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            string selectGameCmdText = $"SELECT ID FROM Review.Game WHERE GameTitle LIKE '%{gameTitle}%'";
            using SqlCommand gameCmd = new(selectGameCmdText, connection);
            using SqlDataReader gameIDReader = await gameCmd.ExecuteReaderAsync();
            int gameID = 0;
            int platformID = 0;
            while (gameIDReader.Read())
            {
                gameID = gameIDReader.GetInt32(0);
            }
            string selectPlatformCmdText = $"SELECT ID FROM Review.Platform WHERE ConsoleName LIKE '%{platform}%'";
            using SqlCommand platformCmd = new(selectPlatformCmdText, connection);
            using SqlDataReader platformIDReader = await platformCmd.ExecuteReaderAsync();
            while (platformIDReader.Read())
            {
                platformID = platformIDReader.GetInt32(0);
            }
            string cmdText = "INSERT INTO Review.GamePlatform (GameID, PlatformID) VALUES (@gameID,@platformID)";

            using SqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@gameID", gameID);
            cmd.Parameters.AddWithValue("@platformID", platformID);
            await cmd.ExecuteReaderAsync();

            await connection.CloseAsync();
            _logger.LogInformation("Executed PostInsertGameAsync");
            return;
        }
        public async Task<IEnumerable<Game>> GetGamesByTitleAsync(string title)
        {
            List<Game> games = new List<Game>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = $"SELECT ID, GameTitle, GameDeveloper, GamePublisher, YearPublished FROM Review.Game WHERE GameTitle like '%{title}%'";

            using SqlCommand cmd = new(cmdText, connection);
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string gameTitle = reader.GetString(1);
                string developerName = reader.GetString(2);
                string publisherName = reader.GetString(3);
                int yearPublished = reader.GetInt32(4);

                List<Tag> tags = new List<Tag>();
                List<Platform> platforms = new List<Platform>();

                string tagsCmdText = $"SELECT t.ID, t.Genre FROM Review.Game as g JOIN Review.GameTags as gt on g.ID = gt.GameID JOIN Review.Tags as t on t.ID = gt.TagID WHERE g.ID = {id}";
                using SqlCommand tagCmd = new(tagsCmdText, connection);
                using SqlDataReader tagReader = await tagCmd.ExecuteReaderAsync();
                while (tagReader.Read())
                {
                    int tagId = tagReader.GetInt32(0);
                    string tagTitle = tagReader.GetString(1);
                    Tag tmpTag = new Tag(tagId, tagTitle);
                    tags.Add(tmpTag);
                }

                string platformCmdText = $"SELECT p.ID, p.ConsoleName FROM Review.Game as g JOIN Review.GamePlatform as gp on g.ID = gp.GameID JOIN Review.Platform as p on p.ID = gp.PlatformID WHERE g.ID = {id}";
                using SqlCommand platformCmd = new(platformCmdText, connection);
                using SqlDataReader platformReader = await platformCmd.ExecuteReaderAsync();
                while (platformReader.Read())
                {
                    int platformId = platformReader.GetInt32(0);
                    string platformTitle = platformReader.GetString(1);
                    Platform tmpPlatform = new Platform(platformId, platformTitle);
                    platforms.Add(tmpPlatform);
                }
                Game tmpGame = new Game(id, title, developerName, publisherName, tags, platforms, yearPublished);

                games.Add(tmpGame);
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetGamesByDeveloperAsync, returned {0} results", games.Count);
            return games;
        }
    }
   
}
