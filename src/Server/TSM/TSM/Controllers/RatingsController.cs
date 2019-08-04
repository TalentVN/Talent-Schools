using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSM.Interfaces;
using TSM.Logging;
using TSM.Models;

namespace TSM.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IAppLogger<RatingsController> _logger;
        private readonly IRatingService _ratingService;
        public RatingsController(
            IAppLogger<RatingsController> logger,
            IRatingService ratingService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _ratingService = ratingService ?? throw new ArgumentNullException(nameof(ratingService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingModel>>> GetRatingsBySchoolId(Guid schoolId)
        {
            var ratings = await _ratingService.GetRatings(schoolId);

            return Ok(ratings);
        }

        [HttpPost]
        public async Task<ActionResult<RatingModel>> Post(CreateRatingRequestModel ratingModel)
        {
            var rating = await _ratingService.CreateRating(ratingModel);

            return Ok(rating);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _ratingService.DeleteRating(id);

            return Ok();
        }
    }
}
