using Entitas;
using UnityEngine.InputSystem;

namespace Project.Scripts.PlayerInputSystems
{
    public class PlayerShootInputSystem : IInitializeSystem, ITearDownSystem
    {
        private readonly EventsContext _context;
        private readonly PlayerInput _playerInput;

        public PlayerShootInputSystem(EventsContext context, PlayerInput playerInput)
        {
            _context = context;
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
            _context.CreateEntity().isOneFrame = true;
        }
    }
}