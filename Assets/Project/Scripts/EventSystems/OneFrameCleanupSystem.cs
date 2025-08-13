using System.Collections.Generic;
using Entitas;

namespace Project.Scripts.EventSystems
{
    public class OneFrameCleanupSystem : ReactiveSystem<EventsEntity>
    {
        public OneFrameCleanupSystem(EventsContext context)
            : base(context)
        {
        }

        protected override ICollector<EventsEntity> GetTrigger(IContext<EventsEntity> context)
            => context.CreateCollector(EventsMatcher.OneFrame);

        protected override bool Filter(EventsEntity entity) => entity.isOneFrame;

        protected override void Execute(List<EventsEntity> entities)
        {
            foreach (EventsEntity entity in entities)
                entity.Destroy();
        }
    }
}