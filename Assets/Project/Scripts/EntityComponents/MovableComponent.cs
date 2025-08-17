using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Project.Scripts.EntityComponents
{
    [Game]
    public sealed class MovableComponent : IComponent
    {
        [PrimaryEntityIndex] public Transform Transform;
        public float Speed;
        public Vector2 Direction;
    }
}
