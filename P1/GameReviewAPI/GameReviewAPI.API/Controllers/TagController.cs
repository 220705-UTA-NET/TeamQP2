using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameReviewAPI.Model;
using GameReviewAPI.Data;

namespace GameReviewAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly TagsIRepository _repo;
        private readonly ILogger<TagController> _logger;
        public TagController(TagsIRepository repo, ILogger<TagController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> getAllTags()
        {
            IEnumerable<Tag> tags;
            try
            {
                tags = await _repo.GetAllTagsAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }
            return tags.ToList();
        }
    }
}
