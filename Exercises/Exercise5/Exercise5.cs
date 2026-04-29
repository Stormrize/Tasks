namespace Exercises.Exercise5;

public class Exercise5
{
    public static void Main(string[] args)
    {
        var teamService = new TeamListService();
        var gameService = new GameListService();

        while (true)
        {
            Console.WriteLine("\n=== Турнірна таблиця ===");
            Console.WriteLine("1. Додати команду");
            Console.WriteLine("2. Редагувати команду");
            Console.WriteLine("3. Видалити команду");
            Console.WriteLine("4. Знайти команду");
            Console.WriteLine("5. Статистика команди");
            Console.WriteLine("--- Ігри ---");
            Console.WriteLine("6. Додати гру");
            Console.WriteLine("7. Переглянути всі ігри");
            Console.WriteLine("8. Видалити гру");
            Console.WriteLine("9. Лідер");
            Console.WriteLine("0. Вихід");

            Console.Write("Ваш вибір: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Назва: ");
                    var name = Console.ReadLine();
                    Console.Write("Країна: ");
                    var country = Console.ReadLine();
                    teamService.AddTeam(name, country);
                    break;

                case "2":
                    Console.Write("ID команди: ");
                    int editId = int.Parse(Console.ReadLine());
                    Console.Write("Нова назва: ");
                    var newName = Console.ReadLine();
                    Console.Write("Нова країна: ");
                    var newCountry = Console.ReadLine();
                    teamService.EditTeamById(editId, newName, newCountry);
                    break;

                case "3":
                    Console.Write("ID для видалення: ");
                    int delId = int.Parse(Console.ReadLine());
                    teamService.DeleteTeamById(delId);
                    break;

                case "4":
                    Console.Write("Пошук: ");
                    var search = Console.ReadLine();
                    var results = teamService.SearchTeams(search);
                    foreach (var t in results)
                        Console.WriteLine($"{t.getId()}. {t.getName()} ({t.getCountry()}) - {t.getPoints()} очок");
                    break;

                // case "5":
                //     Console.Write("ID команди: ");
                //     int statId = int.Parse(Console.ReadLine());
                //     Console.WriteLine(teamService.GetTeamStats(statId, gameService));
                //     break;

                case "6":
                    Console.Write("ID господаря: ");
                    int homeId = int.Parse(Console.ReadLine());
                    Console.Write("ID гостя: ");
                    int awayId = int.Parse(Console.ReadLine());
                    Console.Write("Стадіон: ");
                    var stadium = Console.ReadLine();
                    Console.Write("Голи господаря: ");
                    int homeScore = int.Parse(Console.ReadLine());
                    Console.Write("Голи гостя: ");
                    int awayScore = int.Parse(Console.ReadLine());

                    gameService.AddGame(homeId, awayId, stadium, homeScore, awayScore);
                    
                    var game = gameService.GetAllGames().Last();
                    ApplyGameResult(game, teamService);

                    break;

                case "7":
                    foreach (var g in gameService.GetAllGames())
                    {
                        Console.WriteLine($"{g.getId()}: {g.getHomeTeamId()} vs {g.getAwayTeamId()} | {g.getResult()} | {g.getStadium()}");
                    }
                    break;

                case "8":
                    Console.Write("ID гри: ");
                    int gameId = int.Parse(Console.ReadLine());
                    gameService.DeleteGameById(gameId);
                    break;

                case "9":
                    var leader = teamService.getLeader();
                    if (leader != null)
                        Console.WriteLine($"Лідер: {leader.getName()} ({leader.getPoints()} очок)");
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Невірний вибір");
                    break;
            }
        }
    }

    static void ApplyGameResult(Game game, TeamListService teamService)
    {
        var home = teamService.GetTeamById(game.getHomeTeamId());
        var away = teamService.GetTeamById(game.getAwayTeamId());

        if (home == null || away == null) return;

        if (game.getHomeScore() > game.getAwayScore())
        {
            home.AddPoints(3);
        }
        else if (game.getHomeScore() < game.getAwayScore())
        {
            away.AddPoints(3);
        }
        else
        {
            home.AddPoints(1);
            away.AddPoints(1);
        }
    }
}