using Entitas;
using Project.Scripts;
using Project.Scripts.BulletSpawnSystems;
using Project.Scripts.BulletSpawnSystems.Data;
using Project.Scripts.EnemySpawnSystems;
using Project.Scripts.EnemySpawnSystems.Data;
using Project.Scripts.EntitySystems;
using Project.Scripts.EventSystems;
using Project.Scripts.PlayerInputSystems;
using Project.Scripts.WorkObjects;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Project.Scopes
{
    public class SystemsScope : LifetimeScope
    {
        [SerializeField] private EntityData _playerData;
        [SerializeField] private GameObject _player;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private EnemySpawnConfig _spawnConfig;
        [SerializeField] private EnemySpawnPointsConfig _spawnPointsConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            Contexts contexts = Contexts.sharedInstance;
            Transform playerTransform = _player.transform;
            EnemySpawnPointProvider spawnPointProvider = new (_spawnPointsConfig, playerTransform);
            
            builder.RegisterInstance(_player.transform);
            
            builder
                .RegisterInstance(contexts.game)
                .As<GameContext>()
                .As<IContext<GameEntity>>();

            builder
                .RegisterInstance(contexts.events)
                .As<EventsContext>()
                .As<IContext<EventsEntity>>();
            
            builder
                .Register<GameInitializationSystem>(Lifetime.Singleton)
                .WithParameter(new object[] { _playerData, _player });

            builder.Register<PlayerMoveInputSystem>(Lifetime.Singleton);
            builder.Register<EntitiesMoveSystem>(Lifetime.Singleton);
            builder.Register<FollowSystem>(Lifetime.Singleton);
            
            builder
                .Register<EnemySpawnSystem>(Lifetime.Singleton)
                .WithParameter(new object[] { _spawnConfig, spawnPointProvider, playerTransform });

            builder.Register<OneFrameCleanupSystem>(Lifetime.Singleton);
            builder.Register<BulletSpawnSystem>(Lifetime.Singleton).WithParameter(_bulletConfig);
        }
    }
}