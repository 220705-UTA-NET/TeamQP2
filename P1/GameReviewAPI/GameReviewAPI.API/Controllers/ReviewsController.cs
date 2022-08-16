using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameReviewAPI.Model;
using GameReviewAPI.Data;

namespace GameReviewAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ReviewIRepository _repo;
        private readonly ILogger<ReviewsController> _logger;
        public ReviewsController(ReviewIRepository repo, ILogger<ReviewsController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetAllReviews()
        {
            IEnumerable<Review> reviews;
            try
            {
                reviews = await _repo.GetAllReviewsAsync();
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return reviews.ToList();
        }
        [HttpGet("Descending")]
        public async Task<ActionResult<IEnumerable<AverageReview>>> GetAverageReviewsDescending()
        {
            IEnumerable<AverageReview> ratings;
            try
            {
                ratings = await _repo.GetAverageReviewsDescendingAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return ratings.ToList();
        }
        [HttpGet("Ascending")]
        public async Task<ActionResult<IEnumerable<AverageReview>>> GetAverageReviewsAscending()
        {
            IEnumerable<AverageReview> ratings;
            try
            {
                ratings = await _repo.GetAverageReviewsAscendingAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return ratings.ToList();
        }
        [HttpGet("byID")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByID(string user)
        {
            IEnumerable<Review> reviews;
            try
            {
                reviews = await _repo.GetReviewsByIDAsync(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return reviews.ToList();
        }
        [HttpPost("insertReview")]
        public async Task<ActionResult> PostInsertReview([FromBody]Review review)
        {
            try
            {
                await _repo.PostInsertReviewAsync(review.review,review.starRating,review.userName,review.gameTitle);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return StatusCode(200);
        }
        [HttpDelete("deleteReview")]
        public async Task<ActionResult> DeleteReview(string UserName, string GameTitle)
        {
            try
            {
                await _repo.DeleteReviewAsync(UserName, GameTitle);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return StatusCode(200);
        }
        [HttpGet("gameReview")]
        public async Task<ActionResult<IEnumerable<GameReview>>> GetAllReviewsForGame(string game)
        {
            IEnumerable<GameReview> reviews;
            try
            {
                reviews = await _repo.GetAllReviewsForGameAsync(game);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return reviews.ToList();
        }
    }
}
