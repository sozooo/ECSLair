using Entitas;
using UnityEngine;

namespace Project.Scripts.EntitySystems
{
    public class EntitiesMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _playerGroup;
        
        public EntitiesMoveSystem(GameContext context)
        {
            _playerGroup = context.GetGroup(GameMatcher.Movable);
        }
        
        public void Execute()
        {
            foreach (GameEntity player in _playerGroup)
            {
                Vector2 direction = player.movable.Direction.normalized;
            
                if (direction != Vector2.zero)
                {
                    player.movable.Transform.position += (Vector3)(direction * player.movable.Speed * Time.deltaTime);
                }
            }
        }
    }
}