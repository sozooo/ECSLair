using Leopotam.Ecs;
using Project.Scripts.EntityComponents;
using UnityEngine;

namespace Project.Scripts.EntitySystems
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<MovableComponent, InputEventComponent> _movableFilter;
        
        public void Run()
        {
            foreach (int i in _movableFilter)
            {
                ref MovableComponent movable = ref _movableFilter.Get1(i);
                ref InputEventComponent inputEvent = ref _movableFilter.Get2(i);

                var direction = inputEvent.Direction.normalized;

                if (direction != Vector2.zero)
                {
                    movable.Transform.position += (Vector3)(direction * movable.Speed * Time.deltaTime);
                }
            }
        }
    }
}