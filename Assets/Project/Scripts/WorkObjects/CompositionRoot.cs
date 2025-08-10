using Entitas;
using Project.Scripts.EntitySystems;
using UnityEngine;

namespace Project.Scripts.WorkObjects
{
    public class CompositionRoot : MonoBehaviour
    {
        [SerializeField] private EntityData _playerData;
        
        private Contexts _contexts;
        private Systems _systems;
        
        private void Awake()
        {
            _contexts = Contexts.sharedInstance;
            _systems = new Systems();

            _systems.Add(new GameInitializationSystem(_contexts.game, _playerData));
            _systems.Add(new EntityInputSystem(_contexts.game));
            _systems.Add(new PlayerMoveSystem(_contexts.game));
            _systems.Initialize();
        }
        
        private void Update() => _systems.Execute();

        private void OnDestroy()
        {
            _systems.TearDown();
            _contexts.Reset();
        }
    }
}