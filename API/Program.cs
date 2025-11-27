using Infrastructure.Tmdb;
using RandomCinema.Application.Services;
using RandomCinema.Core.Interfaces;
using RandomCinema.Infrastructure.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddLogging();

// Configure TMDB settings
builder.Services.Configure<TmdbConfig>(
    builder.Configuration.GetSection("Tmdb"));

// Register HttpClient for TMDB API
builder.Services.AddHttpClient<ITmdbApiService, TmdbApiService>(client =>
{
    // Base address will be set in TmdbApiService using TmdbConfig
});

// Register application services
builder.Services.AddScoped<IRecommendationService, RecommendationService>();

// Add CORS if needed for your Vue.js frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:5019") // Vue dev server
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add this to force port 5019
// builder.WebHost.UseUrls("http://localhost:5019/");

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowVueApp");
app.UseStaticFiles(); // For serving Vue.js files from wwwroot

app.UseRouting();
app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();