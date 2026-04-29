namespace Exercises.Exercise5;

public class Game
{
    private static int id = 0;
    private readonly int homeTeamId;
    private readonly int awayTeamId;   
    private readonly string stadium;
    private int homeScore;
    private int awayScore;

    public Game(int homeTeamId, int awayTeamId, string stadium, int homeScore, int awayScore)
    {
        id++;
        homeTeamId = homeTeamId;
        awayTeamId = awayTeamId;
        stadium = stadium;
        homeScore = homeScore;
        awayScore = awayScore;
    }

    public int getId() { return id; }
    public int getHomeTeamId() { return homeTeamId; }
    public int getAwayTeamId() { return awayTeamId; }
    public string getStadium() { return stadium; }
    public int getHomeScore() { return homeScore; }
    public int getAwayScore() { return awayScore; }

    public string getResult()
    { 
        if (homeScore > awayScore)
        {
            return homeScore + ":" + awayScore;
        }
        return awayScore + ":" + homeScore;
    }
}