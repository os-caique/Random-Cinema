namespace RandomCinema.Core.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Overview { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int VoteCount { get; set; }
    
    public string? OriginalLanguage { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string PosterPath { get; set; } = string.Empty;
    public List<int> Genres { get; set; } = new();
}