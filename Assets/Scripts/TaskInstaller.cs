using System.Collections.Generic;
using Zenject;

public class TaskInstaller : Installer<TaskInstaller>
{
    // 1
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<UnitsController>()
            .AsSingle()
            .WithArguments(new List<GameUnit>
        {
            new ("Archer",1),
            new ("Mage",2),
            new ("Knight",4),
            new ("Ork",3)
        });
    }
}