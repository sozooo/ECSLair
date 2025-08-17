using Entitas;
using UnityEngine.InputSystem;
using Zenject;

namespace Project.Scripts.PlayerInputSystems
{
    public class PlayerShootInputSystem : IInitializeSystem, ITearDownSystem
    {
        private readonly EventsContext _context;
        
        [Inject] private PlayerInput _playerInput;

        public PlayerShootInputSystem(EventsContext context)
        {
            _context = context;
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
            EventsEntity shootEvent = _context.CreateEntity();

            shootEvent.isOneFrame = true;
            // shootEvent.AddBulletSpawnEvent();
        }
    }
}