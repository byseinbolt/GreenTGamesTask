using UniRx;
using Zenject;

public class GameUnit
{
    public IReadOnlyReactiveProperty<int> Health { get; }

    public GameUnit(int health)
    {
        Health = new ReactiveProperty<int>(health);
    }
    
    public class UnitsFactory : PlaceholderFactory<int,GameUnit>
    {
        
    }
}