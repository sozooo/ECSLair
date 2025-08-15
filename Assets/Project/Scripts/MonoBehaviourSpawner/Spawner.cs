using UnityEngine;

namespace Project.Scripts.MonoBehaviourSpawner
{
    public class Spawner
    {
        private readonly Pool _pool;

        public Spawner(Pool pool)
        {
            _pool = pool;
        }
        
        public GameObject Spawn(Vector2 position, Quaternion rotation)
        {
            return _pool.Get(position, rotation);
        }
        
        public void Despawn(GameObject instance)
        {
            _pool.Release(instance);
        }
    }
}