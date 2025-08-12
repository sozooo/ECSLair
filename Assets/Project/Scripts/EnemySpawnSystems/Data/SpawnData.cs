using System;
using Project.Scripts.WorkObjects;
using UnityEngine;

namespace Project.Scripts.EnemySpawnSystems.Data
{
    [Serializable]
    public struct SpawnData
    {
        [field: SerializeField] public EnemyType Type { get; private set; }
        [field: SerializeField] public EntityData Enemy { get; private set; }
        [field: SerializeField] public float Weight { get; private set; }
    }
}