using Entitas;
using Project.Scripts.EntitySystems;
using UnityEngine;

namespace Project.Scripts.WorkObjects
{
    public class CompositionRoot : MonoBehaviour
    {
        [SerializeField] private EntityData _playerData;
        
        private Contexts _contexts;
        private Systems _updateSystems;
        private Systems _fixedUpdateSystems;
        
        private void Awake()
        {
            _contexts = Contexts.sharedInstance;
            _updateSystems = new Systems();

            _updateSystems.Add(new GameInitializationSystem(_contexts.game, _playerData));
            _updateSystems.Add(new EntityInputSystem(_contexts.game));
            _updateSystems.Add(new PlayerMoveSystem(_contexts.game));
            
            _updateSystems.Initialize();
        }
        
        private void Update() => _updateSystems.Execute();

        private void FixedUpdate() => _fixedUpdateSystems.Execute();

        private void OnDestroy()
        {
            _updateSystems.TearDown();
            _contexts.Reset();
        }
    }
}