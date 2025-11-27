using System.Text.Json.Serialization;

namespace RandomCinema.Infrastructure.Models;

public class TmdbResponse
{
    [JsonPropertyName("results")]
    public List<TmdbMovie> Results { get; set; } = new();
}