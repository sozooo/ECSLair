using Zenject;

namespace Project.Scripts.Installers
{
    public class ContextsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Contexts contexts = Contexts.sharedInstance;
            
            Container.Bind<GameContext>().FromInstance(contexts.game).AsSingle();
            Container.Bind<EventsContext>().FromInstance(contexts.events).AsSingle();
        }
    }
}