using System.Linq;
using Entitas;
using Project.Scripts.BulletSpawnSystems;
using Project.Scripts.BulletSpawnSystems.Data;
using Project.Scripts.EnemySpawnSystems;
using Project.Scripts.EnemySpawnSystems.Data;
using Project.Scripts.EntitySystems;
using Project.Scripts.EventSystems;
using Project.Scripts.PlayerInputSystems;
using UnityEngine;

namespace Project.Scripts.WorkObjects
{
    public class CompositionRoot : MonoBehaviour
    {
        private readonly PlayerInput _playerInput = new();
        
        [SerializeField] private EntityData _playerData;
        [SerializeField] private EnemySpawnConfig _spawnConfig;
        [SerializeField] private EnemySpawnPointsConfig _spawnPointsConfig;
        [SerializeField] private BulletConfig _bulletConfig;

        [SerializeField] private Transform _player;
        [SerializeField] private Transform _pLayerGun;
        
        private Contexts _contexts;
        private Systems _updateSystems;
        private Systems _reactiveSystems;
        
        private void Awake()
        {
            _contexts = Contexts.sharedInstance;
            
            EnemySpawnPointProvider spawnPointProvider = new (_spawnPointsConfig, _player);
            
            BulletData playerBulletData = _bulletConfig.BulletDatas
                .FirstOrDefault(data => data.Type == BulletType.PlayerBullet);

            _updateSystems = new Systems()
                .Add(new GameInitializationSystem(_contexts.game, _playerData, _player))
                .Add(new PlayerMoveInputSystem(_contexts.game, _playerInput))
                .Add(new EntitiesMoveSystem(_contexts.game))
                .Add(new FollowSystem(_contexts.game))
                .Add(new EnemySpawnSystem(_contexts.game, _spawnConfig, spawnPointProvider, _player))
                .Add(new PlayerShootInputSystem(_contexts.events, _playerInput, _pLayerGun, playerBulletData));
            
            _reactiveSystems = new Systems()
                .Add(new OneFrameCleanupSystem(_contexts.events))
                .Add(new BulletSpawnSystem(_contexts.events, _contexts.game, _bulletConfig));
            
            _updateSystems.Initialize();
        }
        
        private void OnEnable() => _playerInput.Enable();
        
        private void Update() => _updateSystems.Execute();
        
        private void OnDisable() => _playerInput.Disable();

        private void OnDestroy()
        {
            _reactiveSystems.TearDown();
            _updateSystems.TearDown();
            _contexts.Reset();
        }
    }
}