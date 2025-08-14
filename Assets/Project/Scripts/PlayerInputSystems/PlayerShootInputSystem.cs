using Entitas;
using UnityEngine.InputSystem;

namespace Project.Scripts.PlayerInputSystems
{
    public class PlayerShootInputSystem : IInitializeSystem, ITearDownSystem
    {
        private readonly PlayerInput _playerInput;

        public PlayerShootInputSystem(PlayerInput playerInput)
        {
            _playerInput = playerInput;
        }
        
        public void Initialize()
        {
            _playerInput.KeyboardAndMouse.Shoot.performed += Shoot;
        }

        public void TearDown()
        {
            _playerInput.KeyboardAndMouse.Shoot.performed -= Shoot;
        }

        private void Shoot(InputAction.CallbackContext context)
        {
            
        }
    }
}