using System.Collections.Generic;
using Project.Scripts.BulletSpawnSystems.Data;
using UnityEngine;

namespace Project.Scripts.MonoBehaviourSpawner
{
    public class MainBulletSpawner
    {
        private readonly Dictionary<BulletType, Spawner> _spawners;

        public MainBulletSpawner(Dictionary<BulletType, Spawner> spawners)
        {
            _spawners = spawners;
        }

        public GameObject Spawn(BulletType type, Vector2 position, Quaternion rotation)
        {
            return _spawners[type].Spawn(position, rotation);
        }

        public void Despawn(BulletType type, GameObject instance)
        {
            _spawners[type].Despawn(instance);
        }
    }
}