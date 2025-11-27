using RandomCinema.Core.Models;

namespace RandomCinema.Core.Interfaces;

public interface ITmdbApiService
{
    Task<List<Movie>> GetMoviesByVoteCountDescAsync(string genre, int page);
}