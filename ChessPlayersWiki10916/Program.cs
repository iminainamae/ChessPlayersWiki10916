using Microsoft.EntityFrameworkCore;
using ChessPlayersWiki10916.DbContexts;
using ChessPlayersWiki10916.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PlayerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ChessPlayersWikiDb")));
builder.Services.AddControllers();
builder.Services.AddTransient<IPlayerRepo, PlayerRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
