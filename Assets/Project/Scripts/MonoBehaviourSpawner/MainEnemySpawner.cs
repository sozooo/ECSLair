using System.Collections.Generic;
using Project.Scripts.EnemySpawnSystems.Data;
using UnityEngine;

namespace Project.Scripts.MonoBehaviourSpawner
{
    public class MainEnemySpawner
    {
        private readonly Dictionary<EnemyType, Spawner> _spawners;

        public MainEnemySpawner(Dictionary<EnemyType, Spawner> spawners)
        {
            _spawners = spawners;
        }
        
        public GameObject Spawn(EnemyType type, Vector2 position, Quaternion rotation)
        {
            return _spawners[type].Spawn(position, rotation);
        }
        
        public void Despawn(EnemyType type, GameObject instance)
        {
            _spawners[type].Despawn(instance);
        }
    }
}