using Project.Scripts.EnemySpawnSystems.Data;
using UnityEngine;

namespace Project.Scripts.EnemySpawnSystems
{
    public class EnemySpawnPointProvider
    {
        private readonly EnemySpawnPointsConfig _config;
        private readonly Transform _player;
        
        public EnemySpawnPointProvider(EnemySpawnPointsConfig config, Transform player)
        {
            _config = config;
            _player = player;
        }

        public Vector2 GetSpawnPoint()
        {
            float distance = Random.Range(_config.DeadzoneRadius, _config.MaxSpawnDistance);
            Vector2 offset = Random.insideUnitCircle.normalized * distance;

            return (Vector2)_player.position + offset;
        }
    }
}