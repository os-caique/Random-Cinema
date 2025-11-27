using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RandomCinema.Core.Interfaces;
using RandomCinema.Core.Models;
using RandomCinema.Infrastructure.Models;

namespace Infrastructure.Tmdb;

public class TmdbApiService : ITmdbApiService
{
    private readonly HttpClient _httpClient;
    private readonly TmdbConfig _config;
    private readonly ILogger<TmdbApiService> _logger;
    
    public TmdbApiService(HttpClient httpClient, IOptions<TmdbConfig> config,
        ILogger<TmdbApiService> logger)
    {
        _httpClient = httpClient;
        _config = config.Value;
        _logger = logger;
        
        _httpClient.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _config.ApiKey);
    }
    public async Task<List<Movie>> GetMoviesByVoteCountDescAsync(string genre, int page)
    {
        var url = $"{_config.BaseUrl}discover/movie?sort_by=vote_count.desc&page={page}";
        url += $"&language=pt-BR";
        
        if (!string.IsNullOrEmpty(genre))
        {
            url += $"&with_genres={genre}";
        }

        _logger.LogInformation($"Calling TMDB API: {url}");

        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var tmdbResponse = JsonSerializer.Deserialize<TmdbResponse>(json);

        return tmdbResponse?.Results?.Select(m => new Movie
        {
            Id = m.Id,
            Title = m.Title,
            Overview = m.Overview,
            Rating = m.VoteAverage,
            VoteCount = m.VoteCount,
            OriginalLanguage = m.OriginalLanguage,
            ReleaseDate = DateTime.Parse(m.ReleaseDate),
            PosterPath = m.PosterPath
        }).ToList() ?? new List<Movie>();
    }
}