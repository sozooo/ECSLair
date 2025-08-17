using System.Collections.Generic;
using System.Linq;
using Entitas;

namespace Project.Scripts.HealthSystems
{
    public class DeathSystem : ReactiveSystem<GameEntity>
    {
        public DeathSystem(GameContext context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
            => context.CreateCollector(GameMatcher.Health);

        protected override bool Filter(GameEntity entity) => entity.hasHealth;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                if (entity.hasHealth == false)
                    return;
                
                if (entity.health.CurrentHealth <= 0)
                    entity.Destroy();
            }
        }
    }
}