using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameReviewAPI.Model;
using GameReviewAPI.Data;

namespace GameReviewAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserIRepository _repo;
        private readonly ILogger<UserController> _logger;
        public UserController(UserIRepository repo, ILogger<UserController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        [HttpGet("byID")]
        public async Task<ActionResult<string>> GetUser(int id)
        {
            string reviewer;
            try
            {
                reviewer = await _repo.GetUserAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return reviewer;
        }
        [HttpPost("insertReviewer")]
        public async Task<ActionResult> PostInsertUser([FromBody]User reviewer)
        {
            try
            {
                await _repo.PostInsertUserAsync(reviewer.UserID, reviewer.Password);
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
