namespace Exercises.Exercise5;

public class GameListService
{
    private List<Game> games = new List<Game>();

    public void AddGame(int homeTeamId, int awayTeamId, string stadium, int homeScore, int awayScore)
    {
        games.Add(new Game(homeTeamId, awayTeamId, stadium, homeScore, awayScore));
    }

    public List<Game> GetAllGames()
    {
        return games;
    }

    public Game GetGameById(int id)
    {
        foreach (var game in games)
        {
            if (game.getId() == id)
                return game;
        }

        return null;
    }

    public void DeleteGameById(int id)
    {
        var game = GetGameById(id);
        if (game != null)
            games.Remove(game);
    }
}