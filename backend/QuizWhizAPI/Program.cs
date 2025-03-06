#region

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizWhizAPI.Database;
using QuizWhizAPI.Hubs;
using QuizWhizAPI.Logging;
using QuizWhizAPI.Repositories;
using QuizWhizAPI.Services;

#endregion

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
var configuration = builder.Configuration;

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure PostgreSQL Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

// Register Services
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IGameBoardService, GameBoardService>();
builder.Services.AddScoped<IGameSessionService, GameSessionService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IBuzzerService, BuzzerService>();
builder.Services.AddScoped<IFileProcessingService, FileProcessingService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IGameResultService, GameResultService>();
builder.Services.AddScoped<IThemeService, ThemeService>();

// Register Repositories
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IGameBoardRepository, GameBoardRepository>();
builder.Services.AddScoped<IGameSessionRepository, GameSessionRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IBuzzerRepository, BuzzerRepository>();
builder.Services.AddScoped<IGameResultRepository, GameResultRepository>();
builder.Services.AddScoped<IThemeRepository, ThemeRepository>();

// Register SignalR
builder.Services.AddSignalR();

// Register Logger
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

// Enable API versioning
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Ensure the database is migrated and seeded on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable middleware
app.UseRouting();
app.UseCors("AllowAll");
app.UseMiddleware<LoggingMiddleware>();

// Enable Authentication (if needed)
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

// Map Endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<GameHub>("/gamehub");
    endpoints.MapHub<BuzzerHub>("/buzzerhub");
    endpoints.MapHub<ScoreHub>("/scorehub");
    endpoints.MapHub<LobbyHub>("/lobbyhub");
});

app.Run();