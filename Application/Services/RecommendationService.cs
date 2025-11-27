using RandomCinema.Application.Utils;
using RandomCinema.Core.Interfaces;
using RandomCinema.Core.Models;

namespace RandomCinema.Application.Services;

public class RecommendationService : IRecommendationService
{
    private readonly int MAX_ATTEMPTS = 10;
    private readonly ITmdbApiService _tmdbService;

    public RecommendationService(ITmdbApiService tmdbService)
    {
        _tmdbService = tmdbService;
    }

    public async Task<List<Movie>> GetRandomMovieAsync(string genre, int quantity)
    {
        var movies = new List<Movie>();
        var attempts = 0;
        
        while (movies.Count < quantity && attempts < MAX_ATTEMPTS)
        {
            int randomPageValue = GetRandomPageByAttempt(attempts + 1);
            var requestedMovies = await _tmdbService.GetMoviesByVoteCountDescAsync(genre, randomPageValue);
            var filteredMovies = FilterMoviesByScore(requestedMovies);

            AddRecommendedMovies(movies, filteredMovies, quantity);
            attempts++;
        }
        
        return movies;
    }
    
    private int GetRandomPageByAttempt(int attempt)
    {
        int PAGE_LIMIT = 500;
        var random = new Random();
        return random.Next(1, PAGE_LIMIT/attempt);
    }

    private List<Movie> FilterMoviesByScore(List<Movie> movies)
    {
        return movies.Where(
            m => ProbabilitiesCalculator.RuleOfSuccession(m.Rating, m.VoteCount) >= 7.8
            ).ToList();
    }

    private void AddRecommendedMovies(List<Movie> accumulatedMovies, List<Movie> newMovies, int maxQuantity)
    {
        ListAlgorithms.Shuffle(newMovies);
        foreach (var movie in newMovies)
        {
            if (accumulatedMovies.Count >= maxQuantity) break;

            // Avoid duplicates
            if (!accumulatedMovies.Any(m => m.Id == movie.Id))
            {
                accumulatedMovies.Add(movie);
            }
        }
    }
}