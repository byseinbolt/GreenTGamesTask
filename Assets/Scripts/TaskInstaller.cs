using Zenject;

    public class TaskInstaller : Installer<TaskInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<UnitsCreator>().AsSingle();
            Container.BindInterfacesAndSelfTo<UnitsController>().AsSingle();
            Container.BindFactory<int, GameUnit, GameUnit.UnitsFactory>();
        }
    }
