using System.Collections.Generic;
using Project.Scripts.EnemySpawnSystems.Data;
using UnityEngine;

namespace Project.Scripts.MonoBehaviourSpawner
{
    public class Spawner
    {
        private readonly Dictionary<EnemyType, Pool> _pools;

        public Spawner(Dictionary<EnemyType, Pool> pools)
        {
            _pools = pools;
        }
        
        public GameObject Spawn(EnemyType type, Vector3 position, Quaternion rotation)
        {
            return _pools[type].Get(position, rotation);
        }
        
        public void Despawn(EnemyType type, GameObject instance)
        {
            _pools[type].Release(instance);
        }
    }
}