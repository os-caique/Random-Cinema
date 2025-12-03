using Application.Services;
using FluentAssertions;
using Moq;
using RandomCinema.Core.Interfaces;
using RandomCinema.Core.Models;

namespace Application.Tests.Services;

public class RecommendationServiceTests
{
    private readonly Mock<ITmdbApiService> _tmdbServiceMock;
    private readonly RecommendationService _sut;

    public RecommendationServiceTests()
    {
        _tmdbServiceMock = new Mock<ITmdbApiService>();
        _sut = new RecommendationService(_tmdbServiceMock.Object);
    }
    
    [Fact]
    public async Task GetRandomMovieAsync_ValidRequest_ReturnsRequestedQuantity()
    {
        // Arrange
        var genre = "action";
        var quantity = 3;
    
        // Mock movies that pass the filter (rating >= 7.8)
        var highRatedMovies = new List<Movie>
        {
            CreateMovie(1, 8.5, 1000),
            CreateMovie(2, 8.0, 800),
            CreateMovie(3, 7.9, 500),
            CreateMovie(4, 8.2, 1200)
        };

        _tmdbServiceMock
            .Setup(x => x.GetMoviesByVoteCountDescAsync(genre, It.IsAny<int>()))
            .ReturnsAsync(highRatedMovies);

        // Act
        var result = await _sut.GetRandomMovieAsync(genre, quantity);

        // Assert
        result.Should().HaveCount(quantity);
        _tmdbServiceMock.Verify(x => x.GetMoviesByVoteCountDescAsync(genre, It.IsAny<int>()), Times.Once);
    }
    
    [Fact]
    public async Task GetRandomMovieAsync_FiltersLowRatedMovies()
    {
        // Arrange
        var genre = "action";
        var mixedMovies = new List<Movie>
        {
            CreateMovie(1, 8.5, 1000),  // Should pass
            CreateMovie(2, 7.0, 800),   // Should fail
            CreateMovie(3, 7.7, 500),   // Should fail
            CreateMovie(4, 8.2, 1200)   // Should pass
        };

        _tmdbServiceMock
            .Setup(x => x.GetMoviesByVoteCountDescAsync(genre, It.IsAny<int>()))
            .ReturnsAsync(mixedMovies);

        // Act
        var result = await _sut.GetRandomMovieAsync(genre, 10);

        // Assert
        result.Should().HaveCount(2);
        result.Should().Contain(m => m.Id == 1);
        result.Should().Contain(m => m.Id == 4);
        result.Should().NotContain(m => m.Id == 2);
        result.Should().NotContain(m => m.Id == 3);
    }
    
    [Fact]
    public async Task GetRandomMovieAsync_NoDuplicateMovies()
    {
        // Arrange
        var genre = "action";
        var sameMovies = new List<Movie>
        {
            CreateMovie(1, 8.5, 1000),
            CreateMovie(1, 8.5, 1000), // Duplicate ID
            CreateMovie(2, 8.1, 900)
        };

        _tmdbServiceMock
            .Setup(x => x.GetMoviesByVoteCountDescAsync(genre, It.IsAny<int>()))
            .ReturnsAsync(sameMovies);

        // Act
        var result = await _sut.GetRandomMovieAsync(genre, 3);

        // Assert
        result.Should().HaveCount(2); // Only 2 unique movies
        result.Select(m => m.Id).Distinct().Should().HaveCount(2);
    }
    
    [Fact]
    public async Task GetRandomMovieAsync_ReachesMaxAttempts_ReturnsAvailableMovies()
    {
        // Arrange
        var genre = "action";
        var emptyMovies = new List<Movie>(); // Always return empty list
    
        _tmdbServiceMock
            .Setup(x => x.GetMoviesByVoteCountDescAsync(genre, It.IsAny<int>()))
            .ReturnsAsync(emptyMovies);

        // Act
        var result = await _sut.GetRandomMovieAsync(genre, 5);

        // Assert
        result.Should().BeEmpty();
        _tmdbServiceMock.Verify(
            x => x.GetMoviesByVoteCountDescAsync(genre, It.IsAny<int>()), 
            Times.Exactly(10)); // MAX_ATTEMPTS = 10
    }

    private Movie CreateMovie(int id, double rating, int voteCount)
    {
        return new Movie 
        { 
            Id = id, 
            Rating = rating, 
            VoteCount = voteCount,
            Title = $"Movie {id}",
            Overview = "Test overview"
        };
    }
}