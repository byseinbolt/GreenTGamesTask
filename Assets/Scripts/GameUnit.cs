public class GameUnit
{
    public string Name { get; }
    
    public int Health { get; }

    public GameUnit(string name, int health)
    {
        Name = name;
        Health = health;
    }
}