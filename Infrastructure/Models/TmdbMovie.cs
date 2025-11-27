using System.Text.Json.Serialization;

namespace RandomCinema.Infrastructure.Models;

public class TmdbMovie
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    
    [JsonPropertyName("overview")]
    public string Overview { get; set; } = string.Empty;
    
    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }
    
    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }
    
    [JsonPropertyName("original_language")]
    public string? OriginalLanguage { get; set; }
    
    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; } = string.Empty;
    
    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; } = string.Empty;
}