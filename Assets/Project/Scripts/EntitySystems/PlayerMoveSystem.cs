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
            foreach (GameEntity _player in _playerGroup)
            {
                var direction = _player.inputEvent.Direction.normalized;
            
                if (direction != Vector2.zero)
                {
                    _player.movable.Transform.position += (Vector3)(direction * _player.movable.Speed * Time.deltaTime);
                }
            }
        }
    }
}