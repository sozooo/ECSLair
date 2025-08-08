using Leopotam.Ecs;
using Project.Scripts.EntityComponents;
using Project.Scripts.WorkObjects;
using UnityEngine;

namespace Project.Scripts
{
    public class GameInitializationSystem : IEcsInitSystem
    {
        private EntityData _playerData;
        private EcsWorld _world;
        
        public void Init()
        {
            EcsEntity playerEntity = _world.NewEntity();
            playerEntity.Get<InputEventComponent>();
            ref MovableComponent movable = ref playerEntity.Get<MovableComponent>();
            
            GameObject playerPrefab = Object.Instantiate(_playerData.Prefab, Vector3.zero, Quaternion.identity);

            movable.Speed = _playerData.DefaultSpeed;
            movable.Transform = playerPrefab.transform;
        }
    }
}