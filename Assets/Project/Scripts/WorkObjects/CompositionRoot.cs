using Leopotam.Ecs;
using Project.Scripts.EntitySystems;
using UnityEngine;

namespace Project.Scripts.WorkObjects
{
    public class CompositionRoot : MonoBehaviour
    {
        [SerializeField] private EntityData _playerData;
        
        private EcsWorld _world;
        private EcsSystems _systems;
        
        private void Awake()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            
            _systems
                .Add(new GameInitializationSystem())
                .Inject(_playerData);

            _systems.Add(new EntityInputSystem());
            _systems.Add(new PlayerMoveSystem());
            
            _systems.Init();
        }
        
        private void Update() => _systems.Run();

        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        }
    }
}