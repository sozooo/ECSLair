using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Entitas;
using Project.Scripts.EnemySpawnSystems.Data;
using Project.Scripts.MonoBehaviourSpawner;
using Project.Scripts.WorkObjects.WeightedPicker;
using UnityEngine;

namespace Project.Scripts.EnemySpawnSystems
{
    public class EnemySpawnSystem : IInitializeSystem, ITearDownSystem
    {
        private readonly GameContext _context;
        private readonly EnemySpawnConfig _spawnConfig;
        private readonly Spawner _spawner;
        private readonly WeightedRandomPicker<EnemySpawnData> _picker;
        private readonly EnemySpawnPointProvider _spawnPointProvider;
        private readonly Transform _playerTransform;

        private CancellationTokenSource _cancellationTokenSource;
        
        public EnemySpawnSystem(
            GameContext context, 
            EnemySpawnConfig spawnConfig, 
            EnemySpawnPointProvider provider,
            Transform player)
        {
            _context = context;
            _spawnConfig = spawnConfig;
            _spawnPointProvider = provider;
            _playerTransform = player;
            
            _picker = new WeightedRandomPicker<EnemySpawnData>(_spawnConfig.SpawnDataList);
            var pools = new Dictionary<EnemyType, Pool>();

            foreach (var data in _spawnConfig.SpawnDataList.Where(data => pools.ContainsKey(data.Type) == false))
                pools.Add(data.Type, new Pool(data.Enemy.Prefab));
            
            _spawner = new Spawner(pools);
        }
        
        public void Initialize()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            SpawnIteration(_cancellationTokenSource.Token).Forget();
        }

        public void TearDown()
        {
            _cancellationTokenSource?.Cancel();
        }

        private async UniTask SpawnIteration(CancellationToken token)
        {
            await UniTask.WaitForSeconds(_spawnConfig.SpawnInterval, cancellationToken: token);
            
            if(token.IsCancellationRequested)
                return;

            Vector2 position = _spawnPointProvider.GetSpawnPoint();
            EnemySpawnData spawnData = _picker.Pick();
            GameObject enemy = _spawner.Spawn(spawnData.Type, position, Quaternion.identity);

            GameEntity enemyEntity = _context.CreateEntity();
            
            enemyEntity.AddMovable(enemy.transform, spawnData.Enemy.DefaultSpeed, Vector2.zero);
            enemyEntity.AddFollow(_playerTransform);
        }
    }
}