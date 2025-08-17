using Entitas;
using UnityEngine;

namespace Project.Scripts.CollisionDamageSystems.Components
{
    [Events]
    public sealed class CollisionEvent : IComponent
    {
        public Transform CollisionSource;
        public Transform CollisionTarget;
    }
}