using Entitas;
using Project.Scripts.WorkObjects;
using UnityEngine;

namespace Project.Scripts
{
    public class GameInitializationSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly EntityData _playerData;
        private readonly GameObject _player;

        public GameInitializationSystem(GameContext context, EntityData playerData, GameObject player)
        {
            _gameContext = context;
            _playerData = playerData;
            _player = player;
        }
        
        public void Initialize()
        {
            GameEntity playerEntity = _gameContext.CreateEntity();
            
            playerEntity.isInputEvent = true;
            playerEntity.AddMovable(_player.transform, _playerData.DefaultSpeed, Vector2.zero);
        }
    }
}