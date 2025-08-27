using Project.Scripts;
using VContainer;
using VContainer.Unity;

namespace Project.Scopes
{
    public class PlayerInputScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<PlayerInput>(Lifetime.Singleton);
        }
    }
}