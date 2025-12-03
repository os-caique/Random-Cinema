using Application.Services;
using Infrastructure.Tmdb;
using RandomCinema.Core.Interfaces;
using RandomCinema.Infrastructure.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddLogging();

// Configure TMDB settings
builder.Services.Configure<TmdbConfig>(
    builder.Configuration.GetSection("Tmdb"));

// Add CORS if needed for your Vue.js frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:5019")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Register HttpClient
builder.Services.AddHttpClient();

// Register application services
builder.Services.AddScoped<IRecommendationService, RecommendationService>();
builder.Services.AddScoped<ITmdbApiService, TmdbApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseCors("AllowVueApp");

app.UseDefaultFiles(); 
app.UseStaticFiles();  

app.UseRouting();

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();