﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameReviewAPI.Model;
using GameReviewAPI.Data;

namespace GameReviewAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly ILogger<ReviewsController> _logger;
        public ReviewsController(IRepository repo, ILogger<ReviewsController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entry>>> GetAllReviews()
        {
            IEnumerable<Entry> reviews;
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
        public async Task<ActionResult<IEnumerable<Entry>>> GetAverageReviewsDescending()
        {
            IEnumerable<Entry> ratings;
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
        public async Task<ActionResult<IEnumerable<Entry>>> GetAverageReviewsAscending()
        {
            IEnumerable<Entry> ratings;
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
        public async Task<ActionResult<IEnumerable<Entry>>> GetReviewsByID(int ID)
        {
            IEnumerable<Entry> reviews;
            try
            {
                reviews = await _repo.GetReviewsByIDAsync(ID);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return reviews.ToList();
        }
        [HttpPost("insertReview")]
        public async Task<ActionResult> PostInsertReview([FromBody]Entry review)
        {
            try
            {
                await _repo.PostInsertReviewAsync(review.review,review.StarRating,review.ReviewerID,review.GameID);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return StatusCode(200);
        }
        [HttpDelete("deleteReview")]
        public async Task<ActionResult> PostDeleteReview(int reviewerID, int gameID)
        {
            try
            {
                await _repo.PostDeleteReviewAsync(reviewerID, gameID);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return StatusCode(200);
        }
        [HttpGet("gameReview")]
        public async Task<ActionResult<IEnumerable<Entry>>> GetAllReviewsForGame(string game)
        {
            IEnumerable<Entry> reviews;
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
