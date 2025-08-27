using Entitas;
using Project.Scopes;
using Project.Scripts.BulletSpawnSystems;
using Project.Scripts.EnemySpawnSystems;
using Project.Scripts.EntitySystems;
using Project.Scripts.EventSystems;
using Project.Scripts.PlayerInputSystems;
using UnityEngine;
using VContainer;

namespace Project.Scripts.WorkObjects
{
    public class CompositionRoot : MonoBehaviour
    {
        [Inject] private PlayerInput _playerInput;
        [Inject] private GameContext _gameContext;
        [Inject] private EventsContext _eventsContext;

        [SerializeField] private SystemsScope _systemsScope;
        
        private Systems _updateSystems;
        private Systems _reactiveSystems;
        
        private void Awake()
        {
            _updateSystems = new Systems()
                .Add(_systemsScope.Container.Resolve<GameInitializationSystem>())
                .Add(_systemsScope.Container.Resolve<PlayerMoveInputSystem>())
                .Add(_systemsScope.Container.Resolve<EntitiesMoveSystem>())
                .Add(_systemsScope.Container.Resolve<FollowSystem>())
                .Add(_systemsScope.Container.Resolve<EnemySpawnSystem>());

            _reactiveSystems = new Systems()
                .Add(_systemsScope.Container.Resolve<OneFrameCleanupSystem>())
                .Add(_systemsScope.Container.Resolve<BulletSpawnSystem>());
            
            _updateSystems.Initialize();
        }
        
        private void OnEnable() => _playerInput.Enable();
        
        private void Update() => _updateSystems.Execute();
        
        private void OnDisable() => _playerInput.Disable();

        private void OnDestroy()
        {
            _reactiveSystems.TearDown();
            _updateSystems.TearDown();
            
            _gameContext.Reset();
            _eventsContext.Reset();
        }
    }
}