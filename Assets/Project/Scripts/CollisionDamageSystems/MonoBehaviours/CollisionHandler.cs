using UnityEngine;

namespace Project.Scripts.CollisionDamageSystems.MonoBehaviours
{
    public class CollisionHandler : MonoBehaviour
    {
        private EventsContext _eventsContext;
        private Transform _transform;
        
        private void Awake()
        {
            _transform = transform;
        }

        private void OnCollisionEnter(Collision collision)
        {
            _eventsContext
                .CreateEntity()
                .AddCollisionEvent(_transform, collision.transform);
        }
    }
}