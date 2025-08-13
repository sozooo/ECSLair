using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Scripts.PlayerInputSystems
{
    public class PlayerMoveInputSystem : ISystem
    {
        private readonly IGroup<GameEntity> _inputEntities;

        public PlayerMoveInputSystem(GameContext context, PlayerInput playerInput)
        {
            _inputEntities = context.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.InputEvent,
                    GameMatcher.Movable));

            playerInput.KeyboardAndMouse.Direction.performed += SetDirection;
        }

        private void SetDirection(InputAction.CallbackContext callbackContext)
        {
            foreach (GameEntity inputEntity in _inputEntities)
            {
                inputEntity.movable.Direction = callbackContext.ReadValue<Vector2>();
            }
        }
    }
}