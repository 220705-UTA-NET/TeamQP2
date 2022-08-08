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
        private readonly IRepository _repo;
        private readonly ILogger<GameController> _logger;
        public GameController(IRepository repo, ILogger<GameController> logger)
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
        [HttpGet("Genre")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesByGenre(string genre)
        {
            IEnumerable<Game> games;
            try
            {
                games = await _repo.GetGamesByGenreAsync(genre);
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
                await _repo.PostInsertGameAsync(game.GameTitle, game.GameDeveloper, game.GameGenre, game.YearPublished);
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
