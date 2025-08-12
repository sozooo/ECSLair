using System.Threading;
using Cysharp.Threading.Tasks;
using Entitas;
using Project.Scripts.EnemySpawnSystems.Data;

namespace Project.Scripts.EnemySpawnSystems
{
    public class EnemySpawnSystem : IInitializeSystem, ITearDownSystem
    {
        private readonly GameContext _context;
        private readonly EnemySpawnData _spawnData;

        private CancellationTokenSource _cancellationTokenSource;
        
        public EnemySpawnSystem(GameContext context, EnemySpawnData spawnData)
        {
            _context = context;
            _spawnData = spawnData;
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
            await UniTask.WaitForSeconds(_spawnData.SpawnInterval, cancellationToken: token);
            
            if(token.IsCancellationRequested)
                return;
            
            
        }
    }
}