using Entitas;
using UnityEngine;

namespace Project.Scripts.EntityComponents
{
    [Game]
    public sealed class MovableComponent : IComponent
    {
        public Transform Transform;
        public float Speed;
        public Vector2 Direction;
    }
}
