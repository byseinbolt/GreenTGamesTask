using Zenject;

public class GameInstaller : MonoInstaller
{
    // 1
    public override void InstallBindings()
    {
        TaskInstaller.Install(Container);
    }
}