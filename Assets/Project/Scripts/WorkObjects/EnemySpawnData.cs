using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.WorkObjects
{
    [CreateAssetMenu(fileName = "EnemySpawnData", menuName = "Entity/New EnemySpawnData", order = 51)]
    public class EnemySpawnData : ScriptableObject
    {
        [field: SerializeField] public List<SpawnData> SpawnDataList { get; private set; }
        [field: SerializeField] public float SpawnInterval { get; private set; }
    }

    [Serializable]
    public struct SpawnData
    {
        [field: SerializeField] public EnemyType Type { get; private set; }
        [field: SerializeField] public EntityData Enemy { get; private set; }
        [field: SerializeField] public float Weight { get; private set; }
    }

    public enum EnemyType
    {
        Walker,
        Blight,
    }
}