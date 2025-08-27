using Entitas;
using Project.Scripts.BulletSpawnSystems.Data;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Scripts.PlayerInputSystems
{
    public class PlayerShootInputSystem : IInitializeSystem, ITearDownSystem
    {
        private readonly EventsContext _context;
        private readonly PlayerInput _playerInput;
        private readonly Transform _weapon;
        private readonly BulletData _bulletData;

        public PlayerShootInputSystem(
            EventsContext context, 
            PlayerInput playerInput,
            Transform weapon,
            BulletData bulletData)
        {
            _context = context;
            _playerInput = playerInput;
            _weapon = weapon;
            _bulletData = bulletData;
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
            shootEvent.AddBulletSpawnEvent(_bulletData, _weapon.position, _weapon.rotation);
        }
    }
}