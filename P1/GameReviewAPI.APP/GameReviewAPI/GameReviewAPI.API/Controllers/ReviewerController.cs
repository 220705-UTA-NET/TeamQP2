using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameReviewAPI.Model;
using GameReviewAPI.Data;

namespace GameReviewAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly ILogger<ReviewerController> _logger;
        public ReviewerController(IRepository repo, ILogger<ReviewerController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reviewer>>> GetAllReviewers()
        {
            IEnumerable<Reviewer> reviewers;
            try
            {
                reviewers = await _repo.GetAllReviewersAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return reviewers.ToList();
        }
        [HttpGet("byID")]
        public async Task<ActionResult<string>> GetReviewer(int id)
        {
            string reviewer;
            try
            {
                reviewer = await _repo.GetReviewerAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return reviewer;
        }
        [HttpPost("insertReviewer")]
        public async Task<ActionResult> PostInsertReviewer([FromBody]Reviewer reviewer)
        {
            try
            {
                await _repo.PostInsertReviewerAsync(reviewer.UserID, reviewer.Password);
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
