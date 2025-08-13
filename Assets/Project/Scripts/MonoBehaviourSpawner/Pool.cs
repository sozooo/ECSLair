using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.MonoBehaviourSpawner
{
    public class Pool
    {
        private readonly GameObject _prefab;
        private readonly Stack<GameObject> _pool;
        
        public Pool(GameObject prefab)
        {
            _prefab = prefab;
            _pool = new Stack<GameObject>();
        }
        
        public GameObject Get(Vector3 position, Quaternion rotation)
        {
            if(_pool.TryPop(out GameObject instance) == false)
                instance = Object.Instantiate(_prefab);
            
            instance.transform.SetPositionAndRotation(position, rotation);
            instance.SetActive(true);
            
            return instance;
        }

        public void Release(GameObject instance)
        {
            instance.SetActive(false);
            _pool.Push(instance);
        }
    }
}