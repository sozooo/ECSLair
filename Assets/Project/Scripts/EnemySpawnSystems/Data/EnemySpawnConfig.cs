using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.EnemySpawnSystems.Data
{
    [CreateAssetMenu(fileName = "EnemySpawnConfig", menuName = "Entity/New EnemySpawnConfig", order = 51)]
    public class EnemySpawnConfig : ScriptableObject
    {
        [field: SerializeField] public List<EnemySpawnData> SpawnDataList { get; private set; }
        [field: SerializeField] public float SpawnInterval { get; private set; }
    }
}