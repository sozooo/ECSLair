using System.ComponentModel;
using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Project.Scripts.PlayerInputSystems
{
    public class PlayerMoveInputSystem : IInitializeSystem, ITearDownSystem
    {
        private readonly IGroup<GameEntity> _inputEntities;
        
        [Inject] private PlayerInput _playerInput;
        [Inject] private GameContext _gameContext;

        public PlayerMoveInputSystem()
        {
            _inputEntities = _gameContext.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.InputEvent,
                    GameMatcher.Movable));
        }
        
        public void Initialize()
        {
            _playerInput.KeyboardAndMouse.Direction.performed += SetDirection;
        }

        public void TearDown()
        {
            _playerInput.KeyboardAndMouse.Direction.performed -= SetDirection;
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