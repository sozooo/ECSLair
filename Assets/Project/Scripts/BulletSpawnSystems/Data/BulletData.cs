using System;
using UnityEngine;

namespace Project.Scripts.BulletSpawnSystems.Data
{
    [Serializable]
    public struct BulletData
    {
        [field: SerializeField] public BulletType Type { get; private set; }
        [field: SerializeField] public GameObject BulletPrefab { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
    }
}