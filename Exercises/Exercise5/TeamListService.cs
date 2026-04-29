using Microsoft.VisualBasic;

namespace Exercises.Exercise5;

public class TeamListService
{
    private Dictionary<int, Team> teams = new Dictionary<int, Team>();

    public void AddTeam(string name , string country)
    {
        Team team = new Team(name, country);
        teams.Add(team.getId(), team);
    }

    public void EditTeamById(int id, string newName = null, string newCountry = null)
    {
        if (newName != null)
            teams[id].setName(newName);
        if (newCountry != null)
            teams[id].setCountry(newCountry);
    }

    public Dictionary<int, Team> GetAllTeams()
    {
        return teams;
    }

    public Team GetTeamById(int id)
    {
        return teams[id];
    }

    public void DeleteTeamById(int id)
    {
        teams.Remove(id);
    }

    public List<Team> SearchTeams(string name)
    {
        List<Team> result = null;
        foreach (Team team in teams.Values)
        {
            if (team.getName() == name)
            {
                result.Add(team);
            }
        }
        return result;
    }

    public Team getLeader()
    {
        int counter = 0;
        Team result = null;
        foreach (Team team in teams.Values)
        {
            if (team.getPoints() > counter)
            {
                counter = team.getPoints();
                result = team;
            }
        }
        return result;
    }

    public string GetTeamStats(int id, GameListService gameService)
    {
        if (!teams.ContainsKey(id))
            return "Команду не знайдено";

        var team = teams[id];

        int wins = 0, draws = 0, losses = 0;

        foreach (var g in gameService.GetAllGames())
        {
            if (g.getHomeTeamId() != id && g.getAwayTeamId() != id)
                continue;

            if (g.getHomeTeamId() == id)
            {
                if (g.getHomeScore() > g.getAwayScore()) wins++;
                else if (g.getHomeScore() == g.getAwayScore()) draws++;
                else losses++;
            }
            else
            {
                if (g.getAwayScore() > g.getHomeScore()) wins++;
                else if (g.getAwayScore() == g.getHomeScore()) draws++;
                else losses++;
            }
        }

        return $"{team.getName()}: {team.getPoints()} очок | В:{wins} Н:{draws} П:{losses}";
    }
}