using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.EnemySpawnSystems.Data
{
    [CreateAssetMenu(fileName = "EnemySpawnData", menuName = "Entity/New EnemySpawnData", order = 51)]
    public class EnemySpawnData : ScriptableObject
    {
        [field: SerializeField] public List<SpawnData> SpawnDataList { get; private set; }
        [field: SerializeField] public float SpawnInterval { get; private set; }
    }
}