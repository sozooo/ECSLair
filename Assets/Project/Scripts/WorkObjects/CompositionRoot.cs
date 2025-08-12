using Entitas;
using Project.Scripts.EnemySpawnSystems;
using Project.Scripts.EnemySpawnSystems.Data;
using Project.Scripts.EntitySystems;
using UnityEngine;

namespace Project.Scripts.WorkObjects
{
    public class CompositionRoot : MonoBehaviour
    {
        [SerializeField] private EntityData _playerData;
        [SerializeField] private EnemySpawnData _spawnData;
        
        private Contexts _contexts;
        private Systems _updateSystems;
        
        private void Awake()
        {
            _contexts = Contexts.sharedInstance;
            _updateSystems = new Systems();

            _updateSystems.Add(new GameInitializationSystem(_contexts.game, _playerData))
                .Add(new EntityInputSystem(_contexts.game))
                .Add(new EntitiesMoveSystem(_contexts.game))
                .Add(new EnemySpawnSystem(_contexts.game, _spawnData));
            
            _updateSystems.Initialize();
        }
        
        private void Update() => _updateSystems.Execute();

        private void OnDestroy()
        {
            _updateSystems.TearDown();
            _contexts.Reset();
        }
    }
}