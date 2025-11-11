using Microsoft.AspNetCore.Mvc;

namespace RandomCinema.Core.Interfaces;

public interface IRecommendationController
{
    Task<IActionResult> GetRandomMovie(string genre = "");
}