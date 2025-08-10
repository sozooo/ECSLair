using Entitas;
using UnityEngine;

namespace Project.Scripts.EntitySystems
{
    public class PlayerMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _playerGroup;
        
        public PlayerMoveSystem(GameContext context)
        {
            _playerGroup = context.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Movable,
                    GameMatcher.InputEvent));
        }
        
        public void Execute()
        {
            foreach (GameEntity player in _playerGroup)
            {
                var direction = player.inputEvent.Direction.normalized;
            
                if (direction != Vector2.zero)
                {
                    player.movable.Transform.position += (Vector3)(direction * player.movable.Speed * Time.deltaTime);
                }
            }
        }
    }
}