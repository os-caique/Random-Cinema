using RandomCinema.Core.Models;

namespace RandomCinema.Core.Interfaces;

public interface IRecommendationService
{
    Task<List<Movie>> GetRandomMovieAsync(string genre, int quantity);
}