using Entitas;
using UnityEngine;

namespace Project.Scripts.EntitySystems
{
    public class EntityInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _inputEntities;

        public EntityInputSystem(GameContext context)
        {
            _inputEntities = context.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.InputEvent));
        }
        
        public void Execute()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            
            foreach (GameEntity iputEntity in _inputEntities)
            {
                iputEntity.inputEvent.Direction = new Vector2(x, y);
            }
        }
    }
}