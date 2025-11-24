using GameStore.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGamesEndPointName = "GetGame";

// GET games
List<GameDto> games = new List<GameDto>
{
    new GameDto(1, "Cyberpunk 2077", "RPG", 59.99m, new DateOnly(2020, 12, 10)),
    new GameDto(2, "FIFA 23", "Sports", 49.99m, new DateOnly(2022, 9, 27)),
    new GameDto(3, "Call of Duty", "FPS", 69.99m, new DateOnly(2022, 10, 28)),
    new GameDto(4, "Minecraft", "Sandbox", 26.95m, new DateOnly(2011, 11, 18))
};


app.MapGet("games",()=> games);

// GET /games/id

app.MapGet("games/{id}",(int id)=> games.Find(game => game.Id == id)).WithName(GetGamesEndPointName);

// POST /games

app.MapPost("create-games",(CreateGamesDto newGame) =>
{
    GameDto game =new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate);

        games.Add(game);

        return Results.CreatedAtRoute(GetGamesEndPointName, new {id = game.Id},game);
});



app.Run();
