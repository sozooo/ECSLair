using UnityEngine;

namespace Project.Scripts.EnemySpawnSystems.Data
{
    [CreateAssetMenu(fileName = "EnemySpawnPointConfig", menuName = "Entity/New EnemySpawnPointConfig", order = 0)]
    public class EnemySpawnPointsConfig : ScriptableObject
    {
        [field: SerializeField] [field: Range(0f, 20f)] public float MaxSpawnDistance { get; private set; }
        [field: SerializeField] [field: Range(0f, 20f)] public float DeadzoneRadius {get; private set;}

        private void OnValidate()
        {
            MaxSpawnDistance = Mathf.Max(DeadzoneRadius, MaxSpawnDistance);
        }
    }
}