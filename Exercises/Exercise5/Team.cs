namespace Exercises.Exercise5;

public class Team
{
    private static int id = 0;
    private string name;
    private string country;
    private int points;

    public Team(string name, string country)
    {
        if (name == null || country == null) return;
        this.name = name;
        this.country = country;
        this.points = 0;
        id++;
    }

    public int getId() { return id; }
    public string getName() { return name; }
    public string getCountry() { return country; }
    public int getPoints() {return points; } 

    private void setPoints(int points)
    {
        this.points = points;
    }
    public void setName(string name)
    {
        if (name == null) return;
        this.name = name;
    }
    public void setCountry(string country)
    {
        if (country == null) return;
        this.country = country;
    }

    public void AddPoints(int points)
    {
        this.points += points;
    }
}