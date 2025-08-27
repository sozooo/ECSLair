using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.MonoBehaviourSpawner
{
    public class MainSpawner<T>
        where T : Enum
    {
        private readonly Dictionary<T, Spawner> _spawners;

        public MainSpawner(Dictionary<T, Spawner> spawners)
        {
            _spawners = spawners;
        }

        public GameObject Spawn(T type, Vector2 position, Quaternion rotation)
        {
            return _spawners[type].Spawn(position, rotation);
        }

        public void Despawn(T type, GameObject instance)
        {
            _spawners[type].Despawn(instance);
        }
    }
}