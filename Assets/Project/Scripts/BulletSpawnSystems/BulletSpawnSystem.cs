using System.Collections.Generic;
using System.Linq;
using Entitas;
using Project.Scripts.BulletSpawnSystems.Data;
using Project.Scripts.MonoBehaviourSpawner;
using UnityEngine;

namespace Project.Scripts.BulletSpawnSystems
{
    public class BulletSpawnSystem : ReactiveSystem<EventsEntity>
    {
        private readonly GameContext _gameContext;
        private readonly MainBulletSpawner _bulletSpawner;
        
        public BulletSpawnSystem(EventsContext eventsContext, GameContext gameContext, BulletConfig config) 
            : base(eventsContext)
        {
            _gameContext = gameContext;

            var spawners = new Dictionary<BulletType, Spawner>();

            foreach (var data in config.BulletDatas.Where(data => spawners.ContainsKey(data.Type) == false))
                spawners.Add(data.Type, new Spawner(new Pool(data.BulletPrefab)));
            
            _bulletSpawner = new MainBulletSpawner(spawners);
        }

        protected override ICollector<EventsEntity> GetTrigger(IContext<EventsEntity> context)
            => context.CreateCollector(EventsMatcher.BulletSpawnEvent);

        protected override bool Filter(EventsEntity entity)
            => entity.isOneFrame && entity.hasBulletSpawnEvent;

        protected override void Execute(List<EventsEntity> entities)
        {
            foreach (var entity in entities.Where(entity => entity.hasBulletSpawnEvent))
            {
                GameObject bulletView = _bulletSpawner.Spawn(
                    entity.bulletSpawnEvent.BulletData.Type,
                    entity.bulletSpawnEvent.Position,
                    entity.bulletSpawnEvent.Rotation);
                
                _gameContext
                    .CreateEntity()
                    .AddMovable(
                        bulletView.transform, 
                        entity.bulletSpawnEvent.BulletData.Speed, 
                        bulletView.transform.right);
            }
        }
    }
}