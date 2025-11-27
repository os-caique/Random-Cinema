using Microsoft.AspNetCore.Mvc;
using RandomCinema.Core.Interfaces;

namespace RandomCinema.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecommendationController : ControllerBase
{
    private readonly IRecommendationService _recommendationService;

    public RecommendationController(IRecommendationService recommendationService)
    {
        _recommendationService = recommendationService;
    }

    [HttpGet("random")]
    public async Task<IActionResult> GetRandomMovie([FromQuery] string genre = "")
    {
        try
        {
            var movie = await _recommendationService.GetRandomMovieAsync(genre, 3);
            return Ok(movie);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpGet("health")]
    public IActionResult Health()
    {
        return Ok(new { status = "Healthy", timestamp = DateTime.UtcNow });
    }
}