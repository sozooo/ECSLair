using Entitas;
using Project.Scripts.WorkObjects;
using UnityEngine;

namespace Project.Scripts
{
    public class GameInitializationSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly EntityData _playerData;

        public GameInitializationSystem(GameContext context, EntityData playerData)
        {
            _gameContext = context;
            _playerData = playerData;
        }
        
        public void Initialize()
        {
            GameEntity playerEntity = _gameContext.CreateEntity();
            GameObject playerPrefab = Object.Instantiate(_playerData.Prefab, Vector3.zero, Quaternion.identity);
            
            playerEntity.AddInputEvent(Vector2.zero);
            playerEntity.AddMovable(playerPrefab.transform, _playerData.DefaultSpeed);
        }
    }
}