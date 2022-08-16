using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameReviewAPI.Model;
using GameReviewAPI.Data;

namespace GameReviewAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameIRepository _repo;
        private readonly ILogger<GameController> _logger;
        public GameController(GameIRepository repo, ILogger<GameController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetAllGames()
        {
            IEnumerable<Game> games;
            try
            {
                games = await _repo.GetAllGamesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return games.ToList();
        }
        [HttpGet("Developer")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesByDeveloper(string developer)
        {
            IEnumerable<Game> games;
            try
            {
                games = await _repo.GetGamesByDeveloperAsync(developer);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return games.ToList();
        }
        [HttpGet("Platform")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesByPlatform(string platform)
        {
            IEnumerable<Game> games;
            try
            {
                games = await _repo.GetGamesByPlatformAsync(platform);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return games.ToList();
        }
        [HttpGet("Genre")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesByTag(string genre)
        {
            IEnumerable<Game> games;
            try
            {
                games = await _repo.GetGamesByTagsAsync(genre);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return games.ToList();
        }
        [HttpGet("GameTitle")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesByTitle(string title)
        {
            IEnumerable<Game> games;
            try
            {
                games = await _repo.GetGamesByTitleAsync(title);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return games.ToList();
        }
        [HttpPost("insertGame")]
        public async Task<ActionResult> PostInsertGame([FromBody]Game game)
        {
            try
            {
                await _repo.PostInsertGameAsync(game.GameTitle, game.GameDeveloper, game.GamePublisher, game.YearPublished);
                foreach (Tag tag in game.Tags)
                {
                    await _repo.PostInsertGameTagsAsync(game.GameTitle,tag.tag);
                }
                foreach(Platform platform in game.Platforms)
                {
                    await _repo.PostInsertGamePlatformAsync(game.GameTitle, platform.platform);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return StatusCode(200);
        }
    }
}
