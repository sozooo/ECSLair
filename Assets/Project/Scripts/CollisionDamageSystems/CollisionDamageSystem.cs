using System.Collections.Generic;
using Entitas;
using Project.Scripts.CollisionDamageSystems.Components;
using Project.Scripts.HealthSystems.Components;

namespace Project.Scripts.CollisionDamageSystems
{
    public class CollisionDamageSystem : ReactiveSystem<EventsEntity>
    {
        private readonly GameContext _gameContext;
        private readonly Dictionary<(RoleType, RoleType), bool> _collisionMatrix;
        
        public CollisionDamageSystem(EventsContext context, GameContext gameContext) 
            : base(context)
        {
            _gameContext = gameContext;
            
            _collisionMatrix = new Dictionary<(RoleType, RoleType), bool>
            {
                {(RoleType.Bullet, RoleType.Enemy), true},
                {(RoleType.Bullet, RoleType.Player), true},
                {(RoleType.Enemy, RoleType.Player), true},
            };
        }
        
        protected override ICollector<EventsEntity> GetTrigger(IContext<EventsEntity> context)
            => context.CreateCollector(EventsMatcher.CollisionEvent);

        protected override bool Filter(EventsEntity entity) => entity.hasCollisionEvent;

        protected override void Execute(List<EventsEntity> entities)
        {
            foreach (EventsEntity entity in entities)
            {
                if (entity.hasCollisionEvent == false)
                    return;

                GameEntity collisionSource = _gameContext.GetEntityWithMovable(entity.collisionEvent.CollisionSource);
                GameEntity collisionTarget = _gameContext.GetEntityWithMovable(entity.collisionEvent.CollisionTarget);

                if (collisionSource.hasRole == false && collisionTarget.hasRole == false)
                    return;
                
                (RoleType,RoleType) key = (collisionSource.role.Role, collisionTarget.role.Role);
                
                if(_collisionMatrix.TryGetValue(key, out bool canDamage) && canDamage)
                    DealDamage(collisionSource, collisionTarget);
            }
        }

        private void DealDamage(GameEntity source, GameEntity target)
        {
            if (source.hasCollisionDamage == false && target.hasHealth == false)
                return;
            
            HealthComponent targetHealth = target.health;
            
            target.ReplaceHealth(
                targetHealth.CurrentHealth - source.collisionDamage.DamageAmount, 
                targetHealth.MaxHealth,
                targetHealth.RegenerationAmount);
            
            if(source.isBullet)
                source.Destroy();
        }
    }
}