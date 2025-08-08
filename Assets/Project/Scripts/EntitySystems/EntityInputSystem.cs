using Leopotam.Ecs;
using Project.Scripts.EntityComponents;
using UnityEngine;

namespace Project.Scripts.EntitySystems
{
    public class EntityInputSystem : IEcsRunSystem
    {
        private EcsFilter<InputEventComponent> inputEventsFilter;
        
        public void Run()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            
            foreach (int i in inputEventsFilter)
            {
                ref InputEventComponent inputEvent = ref inputEventsFilter.Get1(i);
                
                inputEvent.Direction = new Vector2(x, y);
            }
        }
    }
}